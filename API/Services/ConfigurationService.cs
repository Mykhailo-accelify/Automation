namespace API.Services
{
    using API.Interfaces;
    using DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ConfigurationService : ICRUDService<Configuration>
    {
        private readonly ILogger logger;
        private readonly Context context;

        public ConfigurationService(
            Context context,
            ILogger<Configuration> logger
            )
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task<IEnumerable<Configuration>> GetAll()
        {
            return await context.Configuration
                .ToListAsync();
        }

        public async Task<Configuration?> Get(int id)
        {
            return await context.Configuration
                .Include(i => i.Client)
                .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Configuration?> Create(Configuration Configuration)
        {
            await context.Configuration.AddAsync(Configuration);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return Configuration;
        }

        public async Task<Configuration?> Delete(int id)
        {
            var Configuration = await context.Configuration.SingleOrDefaultAsync(i => i.Id == id);
            if (Configuration == default)
            {
                logger.LogInformation($"Try delete non exist {nameof(Configuration)} entity");
                return default;
            }

            context.Configuration.Remove(Configuration);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return Configuration;
        }

        public async Task<Configuration?> Update(Configuration item)
        {
            var configuration = await Get(item.Id);
            if (configuration == default)
            {
                logger.LogInformation($"Try update non exist {nameof(Configuration)} entity");
                return default;
            }

            context.Entry(configuration).CurrentValues.SetValues(item);

            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            await context.Entry(configuration).Reference(i => i.Client).LoadAsync();
            return configuration;
        }
    }
}
