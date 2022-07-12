namespace API.Interfaces
{
    public interface IUpdateService<TEntity>
        where TEntity : class
    {
        public Task<TEntity?> Update(TEntity item);
    }
}
