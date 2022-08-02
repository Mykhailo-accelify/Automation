using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace API.Services
{
    using API.Interfaces.Services;
    using API.Models.Client;
    using DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ClientService : IClientService
    {
        private readonly ILogger logger;

        private readonly Context context;
        private readonly IHelperService helperService;
        private readonly IStateService stateService;
        private readonly IInfrastructureService infrastructureService;
        private readonly IProductService productService;

        private readonly IEqualityComparer<Configuration> configurationComparer;
        private readonly IEqualityComparer<Infrastructure> infrastructureComparer;
        private readonly IEqualityComparer<Product> productComparer;

        public ClientService(
            Context context,
            ILogger<ClientService> logger,
            IHelperService helperService,
            IStateService stateService,
            IProductService productService,
            IInfrastructureService infrastructureService,
            IEqualityComparer<Configuration> configurationComparer,
            IEqualityComparer<Infrastructure> infrastructureComparer,
            IEqualityComparer<Product> productComparer
        ) {
            this.logger = logger;
            this.context = context;
            this.helperService = helperService;
            this.infrastructureService = infrastructureService;
            this.productService = productService;
            this.stateService = stateService;
            this.configurationComparer = configurationComparer;
            this.infrastructureComparer = infrastructureComparer;
            this.productComparer = productComparer;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await context.Client
                .ToListAsync();
        }

        public async Task<Client?> Get(int id)
        {
            return await context.Client
                .Include(i => i.Configurations)
                .Include(i => i.Infrastructures)
                .ThenInclude(i => i.TypeInfrastructure)
                .Include(i => i.Products)
                .Include(i => i.State)
                .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Client?> Get(string name)
        {
            return await context.Client
                .Include(i => i.Configurations)
                .Include(i => i.Infrastructures)
                .ThenInclude(i => i.TypeInfrastructure)
                .Include(i => i.Products)
                .Include(i => i.State)
                .FirstOrDefaultAsync(i => i.Name == name);
        }

        public async Task<IEnumerable<Client>?> GetRange(IEnumerable<string> names)
        {
            return await context.Client
                .Where(c => names.Any(name => name == c.Name))
                .Include(c => c.State)
                .Include(c => c.Products)
                .Include(c => c.Infrastructures)
                .ThenInclude(i => i.TypeInfrastructure)
                .Include(c => c.Infrastructures)
                .ThenInclude(i => i.Instances)
                .ThenInclude(i => i.TypeInstance)
                .ToArrayAsync();
        }

        public async Task<Client?> Create(Client client)
        {
            if (client?.State is null)
            {
                logger.LogError($"You can't create a {nameof(Client)} without a {nameof(State)}");
                return default;
            }

            if (client.Infrastructures.Count == 0)
            {
                logger.LogError($"You can't create a {nameof(Client)} without a {nameof(Infrastructure)}");
                return default;
            }
            
            var infrastructures = await infrastructureService.GetRange(
                client.Infrastructures?.Select(i => i.Name));

            //await infrastructures.ForEachAsync(i => client.Infrastructures.Add(i));

            var state = await context.State.SingleOrDefaultAsync(s => s.Name == client.State.Name);
            if (state is null)
            {
                logger.LogError($"The specified {nameof(State)} does not exist, create it first");
                return default;
            }
            client.StateId = state.Id;
            client.State = state;

            if (client.Products.Count > 0)
            {
                var productNames = client.Products.Select(p => p.Name).ToArray();
                var products = context.Product.Where(p => productNames.Any(n => n == p.Name));

                client.Products.Clear();
                await products.ForEachAsync(p => client.Products.Add(p));
            }

            client.Abbreviation = client.Abbreviation.ToLower();

            await context.Client.AddAsync(client);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return client;
        }

        public async Task<Client?> Delete(int id)
        {
            var client = await context.Client
                .Include(c => c.State)
                .Include(c => c.Infrastructures)
                .ThenInclude(i => i.TypeInfrastructure)
                .Include(c => c.Products)
                .SingleOrDefaultAsync(i => i.Id == id);

            if (client == default)
            {
                logger.LogInformation($"Try delete non exist {nameof(Client)} entity");
                return default;
            }

            context.Client.Remove(client);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return client;
        }

        public async Task<Client?> Update(Client newClient)
        { 
            //Load exist entities
            var currentClient = await Get(newClient.Id);
            if (currentClient == default)
            {
                logger.LogInformation($"Try update non exist {nameof(Client)} entity");
                return default;
            }

            if (!await SetRelationships(currentClient, newClient)) return default;

            context.Entry(currentClient).CurrentValues.SetValues(newClient);

            //var state = await stateService.Get(newClient.State.Name);

            //if (state is null)
            //{
            //    logger.LogInformation($"{nameof(Client)} must contain {nameof(State).ToLower()}!");
            //    return default;
            //}

            //var infrastructures = await infrastructureService.GetRange(
            //    newClient.Infrastructures?.Select(i => i.Name));

            //var products = await productService.GetRange(
            //    newClient.Products?
            //    .Select(p => p.Name));


            ////Update columns
            //context.Entry(currentClient).CurrentValues.SetValues(newClient);

            ////ONE relationship
            //currentClient.State = state;
            ////currentClient.StateId = state.Id;

            ////MANY relationship
            //currentClient.Products = products;
            //currentClient.Infrastructures = infrastructures;

            //helperService.UpdateRelationCollection(currentClient.Configurations, newClient.Configurations, configurationComparer);
            //helperService.UpdateRelationCollection(currentClient.Infrastructures, newClient.Infrastructures, infrastructureComparer);
            //helperService.UpdateRelationCollection(currentClient.Products, newClient.Products, productComparer);

            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            //await context.Entry(currentClient).Reference(c => c.State).LoadAsync();
            return await Get(currentClient.Id);
        }

        private async Task<bool> SetRelationships(Client? client, Client? source = null)
        {
            if (client is null)
            {
                logger.LogError($"Source {nameof(Client)} for load relationship was null.");
                return false;
            }

            source ??= client;

            if (source.State?.Name is null)
            {
                logger.LogError($"{nameof(Client)} must contain {nameof(State).ToLower()}!");
                return false;
            }

            var state = await stateService.Get(source.State.Name);
            if (state is null)
            {
                logger.LogError($"{nameof(Client)} must contain {nameof(State).ToLower()}!");
                return false;
            }

            client.State = state;

            client.Infrastructures = await infrastructureService.GetRange(
                source.Infrastructures?
                    .Select(i => i.Name));

            client.Products = await productService.GetRange(
                source.Products?
                    .Select(p => p.Name));

            return true;
        }
    }
}