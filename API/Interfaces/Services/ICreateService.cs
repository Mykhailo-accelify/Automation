namespace API.Interfaces.Services
{
    public interface ICreateService<TEntity>
        where TEntity : class
    {
        public Task<TEntity?> Create(TEntity item);
    }
}
