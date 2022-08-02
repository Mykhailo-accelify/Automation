namespace API.Services
{
    using API.Interfaces.Services;
    using DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;

    public class StateService : IStateService
    {
        private readonly ILogger logger;
        private readonly Context context;

        public StateService(
            Context context,
            ILogger<ClientService> logger
            )
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task<IEnumerable<State>> GetAll()
        {
            return await context.State
                .ToListAsync();
        }

        public async Task<IEnumerable<State>?> GetRange(IEnumerable<string>? names)
        {
            if (names is null || names.Count() == 0) return null;

            return await context.State
                .Where(s => names.Any(name => name == s.Name))
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetNames()
        {
            return await context.State
                .Select(s => s.Name)
                .ToListAsync();
        }

        public async Task<State?> Get(int id)
        {
            return await context.State
                .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<State?> Get(string name)
        {
            if (name is null) return null;

            return await context.State
                .SingleOrDefaultAsync(s => name == s.Name);
        }

        public async Task<State?> Create(State state)
        {
            state.Abbreviation = state.Abbreviation.ToUpper();
            await context.State.AddAsync(state);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return state;
        }

        public async Task<State?> Delete(int id)
        {
            var product = await context.State.SingleOrDefaultAsync(i => i.Id == id);
            if (product == default)
            {
                logger.LogInformation($"Try delete non exist {nameof(State)} entity");
                return default;
            }

            context.State.Remove(product);
            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }
            return product;
        }

        public async Task<State?> Update(State item)
        {
            var state = await Get(item.Id);
            if (state == default)
            {
                logger.LogInformation($"Try update non exist {nameof(State)} entity");
                return default;
            }

            context.Entry(state).CurrentValues.SetValues(item);

            if (!await context.SafeSaveChangesAsync(logger))
            {
                return default;
            }

            return state;
        }
    }
}
