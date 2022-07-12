namespace API.Interfaces
{
    using DataAccess.Entities;

    public interface IProductService : ICRUDService<Product>
    {
        public Task<IEnumerable<string>> GetNames();
    }
}
