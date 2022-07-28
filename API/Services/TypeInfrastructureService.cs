namespace API.Services
{
    using API.Interfaces.Services;
    using API.Models;
    using DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;

    public class TypeInfrastructureService : ICRUDService<TypeInfrastructure>
    {
        private readonly ILogger logger;
        private readonly Context context;
        private readonly IHelperService helperService;
        private readonly IEqualityComparer<Infrastructure> infrastructureComparer;

        public TypeInfrastructureService(
            Context context,
            ILogger<ClientService> logger,
            IHelperService helperService,
            IEqualityComparer<Infrastructure> infrastructureComparer)
        {
            this.logger = logger;
            this.context = context;
            this.helperService = helperService;
            this.infrastructureComparer = infrastructureComparer;
        }

        public async Task<IEnumerable<TypeInfrastructure>> GetAll()
        {
            return await context.TypeInfrastructure
                .ToListAsync();
        }

        public async Task<TypeInfrastructure?> Get(int id)
        {
            return await context.TypeInfrastructure
                .Include(i => i.Infrastructures)
                .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<TypeInfrastructure?> Create(TypeInfrastructure typeInfrastructure)
        {
            typeInfrastructure.Name = typeInfrastructure.Name.ToUpper();
            await context.TypeInfrastructure.AddAsync(typeInfrastructure);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return typeInfrastructure;
        }

        public async Task<TypeInfrastructure?> Delete(int id)
        {
            var typeInfrastructure = await context.TypeInfrastructure.SingleOrDefaultAsync(i => i.Id == id);
            if (typeInfrastructure == default)
            {
                logger.LogInformation($"Try update non exist {nameof(TypeInfrastructure)} entity");
                return default;
            }

            context.TypeInfrastructure.Remove(typeInfrastructure);
            await context.SaveChangesAsync();
            return typeInfrastructure;
        }

        public async Task<TypeInfrastructure?> Update(TypeInfrastructure item)
        {
            var typeInfrastructure = await Get(item.Id);
            if (typeInfrastructure == default)
            {
                logger.LogInformation($"Try update non exist {nameof(TypeInfrastructure)} entity");
                return default;
            }

            context.Entry(typeInfrastructure).CurrentValues.SetValues(item);

            helperService.UpdateRelationCollection(typeInfrastructure.Infrastructures, item.Infrastructures, infrastructureComparer);

            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return typeInfrastructure;
        }
    }
}
