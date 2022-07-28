namespace API.Services
{
    using API.Interfaces.Services;
    using API.Models;
    using DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;

    public class InfrastructureService : IInfrastructureService
    {
        private readonly ILogger logger;
        private readonly Context context;
        private readonly IHelperService helperService;
        private readonly IEqualityComparer<Instance> instanceComparer;
        private readonly IEqualityComparer<Client> clientComparer;

        public InfrastructureService(
            Context context,
            ILogger<InfrastructureService> logger,
            IEqualityComparer<Instance> instanceComparer,
            IEqualityComparer<Client> clientComparer,
            IHelperService helperService
            )
        {
            this.logger = logger;
            this.context = context;
            this.instanceComparer = instanceComparer;
            this.clientComparer = clientComparer;
            this.helperService = helperService;
        }

        public async Task<IEnumerable<Infrastructure>> GetAll()
        {
            return await context.Infrastructure
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetNames()
        {
            return await context.Infrastructure
                .Select(i => i.Name)
                .ToListAsync();
        }

        public async Task<Infrastructure?> Get(int id)
        {
            return await context.Infrastructure
                .Include(i => i.Clients)
                .Include(i => i.Instances)
                .ThenInclude(i => i.TypeInstance)
                //.Include(i => i.State)
                .Include(i => i.TypeInfrastructure)
                .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Infrastructure?> Get(string name)
        {
            return await context.Infrastructure
                .Include(i => i.Clients)
                .Include(i => i.Instances)
                .ThenInclude(i => i.TypeInstance)
                //.Include(i => i.State)
                .Include(i => i.TypeInfrastructure)
                .SingleOrDefaultAsync(i => i.Name == name);
        }

        public async Task<Infrastructure?> Create(Infrastructure infrastructure)
        {
            await context.Infrastructure.AddAsync(infrastructure);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return infrastructure;
        }

        public async Task<Infrastructure?> Delete(int id)
        {
            var infrastructure = await context.Infrastructure.SingleOrDefaultAsync(i => i.Id == id);
            if (infrastructure == default)
            {
                logger.LogInformation($"Try delete non exist {nameof(Infrastructure)} entity");
                return default;
            }

            context.Infrastructure.Remove(infrastructure);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return infrastructure;
        }

        public async Task<Infrastructure?> Update(Infrastructure item)
        {
            var infrastructure = await Get(item.Id);
            if (infrastructure == default)
            {
                logger.LogInformation($"Try update non exist {nameof(Infrastructure)} entity");
                return default;
            }

            context.Entry(infrastructure).CurrentValues.SetValues(item);

            helperService.UpdateRelationCollection(infrastructure.Instances, item.Instances, instanceComparer);
            helperService.UpdateRelationCollection(infrastructure.Clients, item.Clients, clientComparer);

            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }
            await context.Entry(infrastructure).Reference(i => i.TypeInfrastructure).LoadAsync();
            //await context.Entry(infrastructure).Reference(i => i.State).LoadAsync();

            return infrastructure;
        }

        public async Task<Infrastructure?> Booking(int clientId, string environment)
        {
            var client = await context.Client.FindAsync(clientId);
            if (client == default)
            {
                logger.LogInformation($"Non exist {nameof(Client)} trying book infrastructure");
                return default;
            }

            environment = environment.ToUpper();
            var infrastructure = context.Infrastructure.SingleOrDefault(
                //i => i.StateId == client.StateId
                i => i.TypeInfrastructure.Name == environment
                && i.MaxStudents - i.Clients.Sum(c => c.AmountStudents) >= client.AmountStudents);
            if (infrastructure == default)
            {
                logger.LogInformation($"Unable to find suitable {nameof(Infrastructure)}");
                return default;
            }

            infrastructure.Clients = new Client[] { client };
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return infrastructure;
        }
    }
}
