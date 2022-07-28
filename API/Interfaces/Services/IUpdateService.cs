namespace API.Interfaces.Services
{
    public interface IUpdateService<TEntity>
        where TEntity : class
    {
        public Task<TEntity?> Update(TEntity item);
    }
}
