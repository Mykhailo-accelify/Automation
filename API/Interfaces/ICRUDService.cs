namespace API.Interfaces
{
    public interface ICRUDService<TEntity> :
        ICreateService<TEntity>,
        IGetService<TEntity>,
        IGetAllService<TEntity>,
        IUpdateService<TEntity>,
        IDeleteService<TEntity>

        where TEntity : class
    {
    }
}
