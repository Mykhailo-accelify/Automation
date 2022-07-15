namespace API.Services
{
    using Interfaces;
    using Models;
    using Models.TeamCity;
    using DataAccess.Entities;
    using System.Collections.Generic;
    using System.Xml;

    public class ConfigService : IConfigService
    {
        private XmlDocument Config { get; } = new XmlDocument();

        private readonly ILogger logger;
        private readonly IConstantService<APIConstant> constantService;
        private readonly IConstantService<InfrastructureVariable> variablesService;
        private readonly IClientService clientService;
        private readonly IInfrastructureService infrastructureService;

        public ConfigService(
            ILogger<ConfigService> logger,
            IConstantService<APIConstant> constantService,
            IConstantService<InfrastructureVariable> variablesService,
            IClientService clientService,
            IInfrastructureService infrastructureService
            )
        {
            this.logger = logger;
            this.constantService = constantService;
            this.variablesService = variablesService;
            this.clientService = clientService;
            this.infrastructureService = infrastructureService;
        }

        public async Task<XmlDocument?> GenerateCustomerEnvironmentConfig(int clientId, string infrastructureName)
        {
            var client = await clientService.Get(clientId);
            if (client is null)
            {
                logger.LogError($"{nameof(Client)} not found with {clientId} id.");
                return default;
            }

            var infrastructure = await infrastructureService.Get(infrastructureName);
            if (infrastructure is null)
            {
                logger.LogError($"{nameof(Infrastructure)} not found with {infrastructureName} id.");
                return default;
            }

            var virtualHostTemplate = await variablesService.Get(ConfigVariables.VirtualHostTemplate);
            if (virtualHostTemplate is null)
            {
                logger.LogError($"{nameof(InfrastructureVariable)} not found with {ConfigVariables.VirtualHostTemplate} name.");
                return default;
            }

            var virtualHost = CreateVirtualHost(virtualHostTemplate.Value.Value, client);

            string[] constKeys = {
                ConfigVariables.CustomerEnvironmentPath,
                ConfigVariables.VirtualHostXPath
            };
            var constants = constantService.GetRange(constKeys);

            if (!SafeLoadXml(constants[ConfigVariables.CustomerEnvironmentPath]))
            {
                return default;
            }

            InsertEnvironment(infrastructure.TypeInfrastructure.Name);
            InsertText(constants[ConfigVariables.VirtualHostXPath], virtualHost);

            return Config;
        }

        public async Task<XmlDocument?> GenerateState504Config(int clientId, string infrastructureName)
        {
            var client = await clientService.Get(clientId);
            if (client is null)
            {
                logger.LogError($"{nameof(Client)} not found with {clientId} id.");
                return default;
            }

            var infrastructure = await infrastructureService.Get(infrastructureName);
            if (infrastructure is null)
            {
                logger.LogError($"{nameof(Infrastructure)} not found with {infrastructureName} id.");
                return default;
            }

            string[] ids = {
                ConfigVariables.State504Path,
                ConfigVariables.DatabaseNameXPath,
                ConfigVariables.DatabaseNameSuffix
            };
            var constants = constantService.GetRange(ids);
            var databaseNameTemplate = await variablesService.Get(ConfigVariables.DatabaseNameTemplate);
            if (databaseNameTemplate is null)
            {
                logger.LogError($"{nameof(InfrastructureVariable)} not found with {ConfigVariables.VirtualHostTemplate} name.");
                return default;
            }

            if (!SafeLoadXml(constants[ConfigVariables.State504Path]))
            {
                return default;
            }


            InsertText(constants[ConfigVariables.DatabaseNameXPath],
                CreateDatabaseName(databaseNameTemplate.Value.Value, client, infrastructure, constants[ConfigVariables.DatabaseNameSuffix]));

            return Config;
        }

        public async Task<XmlDocument?> GenerateStateConfig(int clientId, string infrastructureName)
        {
            var client = await clientService.Get(clientId);
            if (client is null)
            {
                logger.LogError($"{nameof(Client)} not found with {clientId} id.");
                return default;
            }

            var infrastructure = await infrastructureService.Get(infrastructureName);
            if (infrastructure is null)
            {
                logger.LogError($"{nameof(Infrastructure)} not found with {infrastructureName} id.");
                return default;
            }

            string[] ids = {
                ConfigVariables.StatePath,
                ConfigVariables.DatabaseNameXPath,
                ConfigVariables.DatabaseNameSuffix
            };
            var constants = constantService.GetRange(ids);
            var databaseNameTemplate = await variablesService.Get(ConfigVariables.DatabaseNameTemplate);
            if (databaseNameTemplate is null)
            {
                logger.LogError($"{nameof(InfrastructureVariable)} not found with {ConfigVariables.VirtualHostTemplate} name.");
                return default;
            }

            if (!SafeLoadXml(constants[ConfigVariables.StatePath]))
            {
                return default;
            }
            
            InsertText(constants[ConfigVariables.DatabaseNameXPath],
                CreateDatabaseName(databaseNameTemplate.Value.Value, client, infrastructure, constants[ConfigVariables.DatabaseNameSuffix]));

            return Config;
        }

        public async Task<XmlDocument?> GenerateCommonEnvironmentConfig(string infrastructureName)
        {
            var infrastructure = await infrastructureService.Get(infrastructureName);
            if (infrastructure is null)
            {
                logger.LogError($"{nameof(Infrastructure)} not found with {infrastructureName} id.");
                return default;
            }

            string[] ids = {
                ConfigVariables.NetworkLetterSequence,
                ConfigVariables.NetworkLetterCurrent,                
                // File path
                ConfigVariables.EnvironmentCommonPath,
                // Properties XPath
                ConfigVariables.DiskNameXPath,
                ConfigVariables.DestinationIPXPath,
                ConfigVariables.DestinationUserXPath,
                ConfigVariables.NetworkPathXPath,
                ConfigVariables.DatabaseServerXPath,
                ConfigVariables.JobMachineNameXPath,
                ConfigVariables.ImportToolJobMachineNameXPath,
                ConfigVariables.AutoImportPathXPath,
                ConfigVariables.RabbitWorkerMachineIPXPath,
                ConfigVariables.RabbitWorkerMachineUserXPath,
                // Type
                ConfigVariables.FSXType,
                ConfigVariables.IISType,
                ConfigVariables.IISImportToolType,
                ConfigVariables.DBListenerType,
                ConfigVariables.WorkerType
            };
            var constants = constantService.GetRange(ids);

            string[] varKeys = {
                ConfigVariables.NetworkPathTemplate
            };
            var variables = variablesService.GetRange(varKeys);

            if (!SafeLoadXml(constants[ConfigVariables.EnvironmentCommonPath]))
            {
                return default;
            }

            var fsx = infrastructure.Instances.SingleOrDefault(i => i.TypeInstance.Name == constants[ConfigVariables.FSXType]);
            var networkPath = variables[ConfigVariables.NetworkPathTemplate].Replace(ConfigVariables.FSXPlacehodler, fsx?.Endpoint);
            InsertText(constants[ConfigVariables.NetworkPathXPath], networkPath);
            InsertText(constants[ConfigVariables.AutoImportPathXPath], networkPath);

            InsertText(constants[ConfigVariables.DiskNameXPath], GenerateDiskLetter(
                constants[ConfigVariables.NetworkLetterSequence],
                constants[ConfigVariables.NetworkLetterCurrent]).ToString());

            var job = infrastructure.Instances.SingleOrDefault(i => i.TypeInstance.Name == constants[ConfigVariables.IISType]);
            InsertText(constants[ConfigVariables.DestinationIPXPath], job?.Endpoint);
            InsertText(constants[ConfigVariables.DestinationUserXPath], job?.Secret);
            InsertText(constants[ConfigVariables.JobMachineNameXPath], job?.Endpoint);

            var import = infrastructure.Instances.SingleOrDefault(i => i.TypeInstance.Name == constants[ConfigVariables.IISImportToolType]);
            InsertText(constants[ConfigVariables.ImportToolJobMachineNameXPath], import?.Endpoint);

            var db = infrastructure.Instances.SingleOrDefault(i => i.TypeInstance.Name == constants[ConfigVariables.DBListenerType]);
            InsertText(constants[ConfigVariables.DatabaseServerXPath], db?.Endpoint);

            var worker = infrastructure.Instances.SingleOrDefault(i => i.TypeInstance.Name == constants[ConfigVariables.WorkerType]);
            InsertText(constants[ConfigVariables.RabbitWorkerMachineIPXPath], worker?.Endpoint);
            InsertText(constants[ConfigVariables.RabbitWorkerMachineUserXPath], worker?.Secret);

            return Config;
        }

        public async Task<TeamCityConfiguration?> GenerateTeamCityConfiguration(int clientId, string infrastructureName)
        {
            var client = await clientService.Get(clientId);
            if (client is null)
            {
                logger.LogError($"{nameof(Client)} not found with {clientId} id.");
                return default;
            }

            var infrastructure = await infrastructureService.Get(infrastructureName);
            if (infrastructure is null)
            {
                logger.LogError($"{nameof(Infrastructure)} not found with {infrastructureName} id.");
                return default;
            }

            string[] constKeys = {
                ConfigVariables.RabbitType,
                ConfigVariables.IISType,
                ConfigVariables.IISImportToolType,
                ConfigVariables.LoadBalancerWebType,
                ConfigVariables.LoadBalancerImportType,
                ConfigVariables.FSXType,
                ConfigVariables.DBListenerType,
                ConfigVariables.Domain,
                ConfigVariables.SubDomain,
                ConfigVariables.RootDomain,
                ConfigVariables.DatabaseNameSuffix
            };
            var constants = constantService.GetRange(constKeys);

            string[] varKeys = {
                ConfigVariables.VirtualHostTemplate,
                ConfigVariables.ImportToolSiteNameTemplate,
                ConfigVariables.SiteNameTemplate,
                ConfigVariables.DomainTemplate,
                ConfigVariables.DatabaseNameTemplate
            };
            var variables = variablesService.GetRange(varKeys);

            var cfg = new TeamCityConfiguration
            {
                Products = client.Products.Select(c => c.Name).ToArray(),
                StateAbbreviation = client.State.Abbreviation,
                Domain = string.Format(variables[ConfigVariables.DomainTemplate],
                constants[ConfigVariables.SubDomain],
                constants[ConfigVariables.Domain],
                constants[ConfigVariables.RootDomain]),
                SiteName = string.Format(variables[ConfigVariables.SiteNameTemplate],
                client.Abbreviation,
                client.State.Abbreviation.ToLower())
            };

            var rabbit = infrastructure.Instances.SingleOrDefault(i => i.TypeInstance.Name == constants[ConfigVariables.RabbitType]);
            if (rabbit is null)
            {
                logger.LogInformation("Instance RabbitMQ not found on this infrastructure.");
            }
            else
            {
                cfg.RabbitMQ = new RabbitMQ
                {
                    URL = rabbit.Endpoint,
                    Credentional = rabbit.Secret,
                    VirtualHost = CreateVirtualHost(variables[ConfigVariables.VirtualHostTemplate], client)
                };
            }

            var loadBalancerWeb = infrastructure.Instances.SingleOrDefault(i => i.TypeInstance.Name == constants[ConfigVariables.LoadBalancerWebType]);
            cfg.LoadBalancerWeb = loadBalancerWeb?.Endpoint;

            var fsx = infrastructure.Instances.SingleOrDefault(i => i.TypeInstance.Name == constants[ConfigVariables.FSXType]);
            cfg.FSXDNS = fsx?.Endpoint;
            cfg.EnvironmentFolder = infrastructure.ConfigurationFolder;
            cfg.FSXFolder = GenerateFSXFolderName(infrastructure);

            var dbListener = infrastructure.Instances.SingleOrDefault(i => i.TypeInstance.Name == constants[ConfigVariables.DBListenerType]);
            cfg.DatabaseListenerName = dbListener?.Endpoint;
            cfg.DatabaseName = CreateDatabaseName(variables[ConfigVariables.DatabaseNameTemplate], client, infrastructure, constants[ConfigVariables.DatabaseNameSuffix]);

            cfg.SiteIISs = new List<IIS>();
            var iiSs = infrastructure.Instances.Where(i => i.TypeInstance.Name == constants[ConfigVariables.IISType]);
            foreach (var iis in iiSs)
            {
                cfg.SiteIISs.Add(new IIS
                {
                    HostName = iis.Endpoint,
                    UserName = iis.Secret,
                    UserPassword = iis.Secret
                });
            }

            if (client.Products.Any(p => p.Name == ConfigVariables.ImportProduct))
            {
                var loadBalancerImport = infrastructure.Instances.SingleOrDefault(i => i.TypeInstance.Name == constants[ConfigVariables.LoadBalancerImportType]);
                cfg.LoadBalancerImport = loadBalancerImport?.Endpoint;
                cfg.ImportToolSiteName = string.Format(variables[ConfigVariables.ImportToolSiteNameTemplate],
                    client.Abbreviation,
                    client.State.Abbreviation.ToLower());

                cfg.ImportToolIISs = new List<IIS>();
                iiSs = infrastructure.Instances.Where(i => i.TypeInstance.Name == constants[ConfigVariables.IISImportToolType]);
                foreach (var iis in iiSs)
                {
                    cfg.ImportToolIISs.Add(new IIS
                    {
                        HostName = iis.Endpoint,
                        UserName = iis.Secret,
                        UserPassword = iis.Secret
                    });
                }

            }

            return cfg;
        }


        public async Task<IEnumerable<InfrastructureTC>?> GenerateTeamCityDeleteConfiguration(IEnumerable<string> names)
        {
            var clients = await clientService.GetRange(names);
            if (clients is null)
            {
                logger.LogError($"{nameof(Client)} not found.");
                return default;
            }

            string[] constKeys = {
                ConfigVariables.RabbitType,
                ConfigVariables.IISType,
                ConfigVariables.IISImportToolType,
                ConfigVariables.FSXType,
                ConfigVariables.SubDomain,
                ConfigVariables.Domain,
                ConfigVariables.RootDomain

            };
            var constants = constantService.GetRange(constKeys);

            string[] varKeys = {
                ConfigVariables.DistrictNameTemplate,
                ConfigVariables.DistrictNameImportTemplate,
                ConfigVariables.DomainTemplate
            };
            var variables = variablesService.GetRange(varKeys);

            var infrastructures = new List<InfrastructureTC>();
            foreach (var client in clients)
            {
                foreach (var infrastructure in client.Infrastructures)
                {
                    if (infrastructures.All(i => i.Name != infrastructure.Name))
                    {
                        infrastructures.Add(new InfrastructureTC()
                        {
                            Name = infrastructure.Name,
                            Domain = string.Format(variables[ConfigVariables.DomainTemplate],
                            constants[ConfigVariables.SubDomain],
                            constants[ConfigVariables.Domain],
                            constants[ConfigVariables.RootDomain]),

                            IIS = new IISGroup()
                            {
                                Web = infrastructure.Instances
                                .Where(i => i.TypeInstance.Name == constants[ConfigVariables.IISType])
                                .Select(iis => new IISTC() { Host = iis.Endpoint }),

                                Import = infrastructure.Instances
                                .Where(i => i.TypeInstance.Name == constants[ConfigVariables.IISImportToolType])
                                .Select(iis => new IISTC() { Host = iis.Endpoint })
                            },

                            FSX = new FSXTC()
                            {
                                Host = infrastructure.Instances
                                    .SingleOrDefault(i => i.TypeInstance.Name == constants[ConfigVariables.FSXType])?
                                .Endpoint,

                                Folder = GenerateFSXFolderName(infrastructure)
                            },

                            RabbitMQ = new RabbitMQTC()
                            {
                                URL = infrastructure.Instances
                                    .SingleOrDefault(i => i.TypeInstance.Name == constants[ConfigVariables.RabbitType])?
                                .Endpoint
                            }
                        });
                    }

                    var parameters = new Dictionary<string, string>(new[]
                    {
                       ConfigVariables.Abbreviation(client),
                       ConfigVariables.Abbreviation(client.State)
                    });
                    infrastructures
                        .SingleOrDefault(i => i.Name == infrastructure.Name)?
                        .Clients
                        .Add(new ClientTC()
                        {
                            DistrictName = (await FillTemplate(variables[ConfigVariables.DistrictNameTemplate], parameters))?.ToLower(),
                            ImportSite = (await FillTemplate(variables[ConfigVariables.DistrictNameImportTemplate], parameters))?.ToLower()
                        });
                }
            }

            return infrastructures;
        }

        private async Task<string?> FillTemplate(string template, IDictionary<string, string> parameters)
        {
            var constant = await constantService.Get(ConfigVariables.ParametrTemplate);
            if (constant is null || !constant.HasValue)
            {
                logger.LogError($"{ConfigVariables.ParametrTemplate} constant not found in database.");
                return null;
            }

            var templateParameter = constant.Value.Value;
            var result = template;

            foreach (var param in parameters)
            {
                var oldValue = string.Format(templateParameter, param.Key);
                result = result.Replace(oldValue, param.Value);
            }

            return result;
        }
        

        private char? GenerateDiskLetter(string seqence, string current)
        {
            var index = seqence.IndexOf(current, StringComparison.Ordinal);
            index++;

            if (index >= seqence.Length)
            {
                var message = "End letters for network drive.";
                logger.LogError(message);
                return null;
            }

            return seqence[index];
        }


        private string? GenerateFSXFolderName(Infrastructure infrastructure)
        {
            if (infrastructure?.TypeInfrastructure?.Name is null)
            {
                logger.LogError($"{nameof(TypeInfrastructure)} null while {nameof(CreateVirtualHost)}.");
                return null;
            }

            return infrastructure.TypeInfrastructure.Name.ToUpper();
        }

        private string? CreateVirtualHost(string template, Client client)
        {
            if (client is null)
            {
                logger.LogError($"{nameof(Client)} null while {nameof(CreateVirtualHost)}.");
                return null;
            }

            return string.Format(template, client.Abbreviation.ToLower(), client.State.Abbreviation.ToLower());
        }

        private string? CreateDatabaseName(string template, Client client, Infrastructure infrastructure, string DatabaseNameSuffix)
        {
            if (client is null)
            {
                logger.LogError($"{nameof(Client)} null while {nameof(CreateVirtualHost)}.");
                return null;
            }
            if (infrastructure?.TypeInfrastructure is null)
            {
                logger.LogError($"{nameof(TypeInfrastructure)} null while {nameof(CreateVirtualHost)}.");
                return null;
            }

            var databaseClientVariable = char.ToUpper(client.Abbreviation[0]) + client.Abbreviation.Substring(1).ToLower();

            return string.Format(template, infrastructure.TypeInfrastructure.Name.ToUpper(),
                client.State.Abbreviation.ToUpper(), databaseClientVariable, DatabaseNameSuffix);
        }

        private bool SafeLoadXml(string? path)
        {
            if (path == default)
            {
                logger.LogWarning("Path is empty");
                return false;
            }

            try
            {
                Config.Load(path);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return false;
            }

            return true;
        }

        private void InsertEnvironment(string? environment)
        {
            if (environment == default)
            {
                logger.LogWarning("Environment is empty.");
                return;
            }

            if (Config.FirstChild is null
                || Config.FirstChild is not XmlComment)
            {
                logger.LogWarning("Incorrect xml.");
                return;
            }

            Config.FirstChild.Value = environment;
        }

        private void InsertText(string xpath, string? text)
        {
            if (xpath == default || text == default)
            {
                logger.LogWarning($"XPath or text to insert is empty, xpath: {xpath}, text: {text}.");
                return;
            }

            XmlElement? root = Config.DocumentElement;
            var node = root?.SelectSingleNode(xpath);
            if (node is null)
            {
                logger.LogWarning($"Can't find {xpath}");
                return;
            }

            XmlText xmlText = Config.CreateTextNode(text);
            node.AppendChild(xmlText);
        }
    }
}