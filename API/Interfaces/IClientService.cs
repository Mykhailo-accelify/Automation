namespace API.Interfaces
{
    using DataAccess.Entities;

    public interface IClientService : ICRUDService<Client>
    {
        public Task<Client?> Get(string name);
    }
}
