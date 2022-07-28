namespace API.Interfaces.Services
{
    public interface IGetService<TEntity>
        where TEntity : class
    {
        public Task<TEntity?> Get(int id);
    }
}
