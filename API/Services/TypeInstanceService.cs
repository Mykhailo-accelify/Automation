namespace API.Services
{
    using API.Interfaces;
    using DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;

    public class TypeInstanceService : ICRUDService<TypeInstance>
    {
        private readonly ILogger logger;
        private readonly Context context;
        private readonly IHelperService helperService;
        private readonly IEqualityComparer<Instance> instanceComparer;

        public TypeInstanceService(
            Context context,
            ILogger<ClientService> logger,
            IHelperService helperService,
            IEqualityComparer<Instance> instanceComparer)
        {
            this.logger = logger;
            this.context = context;
            this.helperService = helperService;
            this.instanceComparer = instanceComparer;
        }

        public async Task<IEnumerable<TypeInstance>> GetAll()
        {
            return await context.TypeInstance
                .ToListAsync();
        }

        public async Task<TypeInstance?> Get(int id)
        {
            return await context.TypeInstance
                .Include(i => i.Instances)
                .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<TypeInstance?> Create(TypeInstance typeInstance)
        {
            await context.TypeInstance.AddAsync(typeInstance);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return typeInstance;
        }

        public async Task<TypeInstance?> Delete(int id)
        {
            var typeInstance = await context.TypeInstance.SingleOrDefaultAsync(i => i.Id == id);
            if (typeInstance == default)
            {
                logger.LogInformation($"Try delete non exist {nameof(TypeInstance)} entity");
                return default;
            }

            context.TypeInstance.Remove(typeInstance);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return typeInstance;
        }

        public async Task<TypeInstance?> Update(TypeInstance item)
        {
            var typeInstance = await Get(item.Id);
            if (typeInstance == default)
            {
                logger.LogInformation($"Try update non exist {nameof(TypeInstance)} entity");
                return default;
            }

            context.Entry(typeInstance).CurrentValues.SetValues(item);

            helperService.UpdateRelationCollection(typeInstance.Instances, item.Instances, instanceComparer);

            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return typeInstance;
        }
    }
}