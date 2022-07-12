namespace API.Interfaces
{
    public interface IGetAllService<TEntity>
        where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAll();
    }
}
