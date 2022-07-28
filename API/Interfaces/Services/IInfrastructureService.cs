namespace API.Interfaces.Services
{
    using DataAccess.Entities;

    public interface IInfrastructureService : ICRUDService<Infrastructure>
    {
        public Task<IEnumerable<string>> GetNames();

        public Task<Infrastructure?> Get(string name);

        public Task<Infrastructure?> Booking(int clientId, string environment);
    }
}
