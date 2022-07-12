namespace API.Interfaces
{
    public interface IDeleteService<TEntity>
        where TEntity : class
    {
        public Task<TEntity?> Delete(int id);
    }
}
