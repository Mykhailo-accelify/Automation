namespace API.Services
{
    using API.Interfaces;
    using API.Models.Client;
    using DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ClientService : IClientService
    {
        private readonly ILogger logger;
        private readonly Context context;
        private readonly IHelperService helperService;
        private readonly IEqualityComparer<Configuration> configurationComparer;
        private readonly IEqualityComparer<Infrastructure> infrastructureComparer;
        private readonly IEqualityComparer<Product> productComparer;

        public ClientService(
            Context context,
            ILogger<ClientService> logger,
            IHelperService helperService,
            IEqualityComparer<Configuration> configurationComparer,
            IEqualityComparer<Infrastructure> infrastructureComparer,
            IEqualityComparer<Product> productComparer
            )
        {
            this.logger = logger;
            this.context = context;
            this.helperService = helperService;
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

            //TODO: Move to func
            var infrastructureNames = client.Infrastructures.Select(i => i.Name).ToArray();
            var infrastructures = context.Infrastructure.Where(i => infrastructureNames.Any(name => name == i.Name));
            client.Infrastructures.Clear();
            await infrastructures.ForEachAsync(i => client.Infrastructures.Add(i));

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
            var client = await context.Client.SingleOrDefaultAsync(i => i.Id == id);
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

        public async Task<Client?> Update(Client item)
        {
            var client = await Get(item.Id);
            if (client == default)
            {
                logger.LogInformation($"Try update non exist {nameof(Client)} entity");
                return default;
            }

            context.Entry(client).CurrentValues.SetValues(item);

            helperService.UpdateRelationCollection(client.Configurations, item.Configurations, configurationComparer);
            helperService.UpdateRelationCollection(client.Infrastructures, item.Infrastructures, infrastructureComparer);
            helperService.UpdateRelationCollection(client.Products, item.Products, productComparer);

            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            await context.Entry(client).Reference(c => c.State).LoadAsync();
            return client;
        }
    }
}