namespace API.Interfaces
{
    using DataAccess.Entities;

    public interface IStateService : ICRUDService<State>
    {
        public Task<IEnumerable<string>> GetNames();
    }
}
