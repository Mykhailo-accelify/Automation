namespace API.Services
{
    using API.Interfaces;
    using DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;

    public class APIConstantService : IConstantService<APIConstant>
    {
        private readonly ILogger logger;
        private readonly Context context;

        public APIConstantService(
            Context context,
            ILogger<APIConstantService> logger
            )
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task<IDictionary<string, string>> GetAll()
        {
            return await context.APIConstant.ToDictionaryAsync(c => c.Name, c => c.Value);
        }

        public IDictionary<string, string> GetRange(ICollection<string> names)
        {
            return context.APIConstant
                .Where(c => names.Contains(c.Name))
                .ToDictionary(c => c.Name, c => c.Value);
        }

        public async Task<KeyValuePair<string, string>?> Get(string name)
        {
            var constant = await context.APIConstant.SingleOrDefaultAsync(i => i.Name == name);
            if (constant == default)
            {
                logger.LogInformation($"Unable to find {nameof(APIConstant)} with name: {name}");
                return default;
            }

            return new KeyValuePair<string, string>(constant.Name, constant.Value);
        }

        public async Task<APIConstant?> Create(APIConstant APIConstant)
        {
            await context.APIConstant.AddAsync(APIConstant);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return APIConstant;
        }

        public async Task<APIConstant?> Delete(string id)
        {
            var APIConstant = await context.APIConstant.SingleOrDefaultAsync(i => i.Name == id);
            if (APIConstant == default)
            {
                logger.LogInformation($"Try delete non exist {nameof(APIConstant)} entity");
                return default;
            }

            context.APIConstant.Remove(APIConstant);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return APIConstant;
        }

        public async Task<APIConstant?> Update(APIConstant item)
        {
            context.APIConstant.Update(item);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return item;
        }
    }
}