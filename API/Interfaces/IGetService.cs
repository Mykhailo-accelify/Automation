namespace API.Interfaces
{
    public interface IGetService<TEntity>
        where TEntity : class
    {
        public Task<TEntity?> Get(int id);
    }
}
