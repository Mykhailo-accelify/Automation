namespace API.Interfaces.Services
{
    using DataAccess.Entities;

    public interface IClientService : ICRUDService<Client>
    {
        public Task<Client?> Get(string name);

        public Task<IEnumerable<Client>?> GetRange(IEnumerable<string> clients);

    }
}
