namespace API.Interfaces.Services
{
    using DataAccess.Entities;

    public interface IProductService : ICRUDService<Product>
    {
        public Task<IEnumerable<string>> GetNames();
    }
}
