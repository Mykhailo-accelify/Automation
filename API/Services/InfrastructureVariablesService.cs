namespace API.Services
{
    using API.Interfaces.Services;
    using API.Models;
    using DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;

    public class InfrastructureVariablesService : IConstantService<InfrastructureVariable>
    {
        private readonly ILogger logger;
        private readonly Context context;

        public InfrastructureVariablesService(
            Context context,
            ILogger<InfrastructureVariablesService> logger
            )
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task<IDictionary<string, string>> GetAll()
        {
            return await context.InfrastructureVariables
                .ToDictionaryAsync(c => c.Name, c => c.Value);
        }

        public IDictionary<string, string> GetRange(ICollection<string> ids)
        {
            return context.InfrastructureVariables
                .Where(c => ids.Contains(c.Name))
                .ToDictionary(c => c.Name, c => c.Value);
        }

        public async Task<KeyValuePair<string, string>?> Get(string id)
        {
            var constant = await context.InfrastructureVariables.SingleOrDefaultAsync(i => i.Name == id);
            if (constant == default)
            {
                logger.LogInformation($"Unable to find {nameof(InfrastructureVariable)} with name: {id}");
                return default;
            }

            return new KeyValuePair<string, string>(constant.Name, constant.Value);
        }

        public async Task<InfrastructureVariable?> Create(InfrastructureVariable InfrastructureVariables)
        {
            await context.InfrastructureVariables.AddAsync(InfrastructureVariables);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return InfrastructureVariables;
        }

        public async Task<InfrastructureVariable?> Delete(string id)
        {
            var infrastructureVariable = await context.InfrastructureVariables.SingleOrDefaultAsync(i => i.Name == id);
            if (infrastructureVariable == default)
            {
                logger.LogInformation($"Try delete non exist {nameof(infrastructureVariable)} entity");
                return default;
            }

            context.InfrastructureVariables.Remove(infrastructureVariable);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return infrastructureVariable;
        }

        public async Task<InfrastructureVariable> Update(InfrastructureVariable item)
        {
            context.InfrastructureVariables.Update(item);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return item;
        }
    }
}
