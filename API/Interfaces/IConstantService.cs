namespace API.Interfaces
{
    public interface IConstantService<T> :
        ICreateService<T>,
        IUpdateService<T>
        where T : class
    {
        public Task<IDictionary<string, string>> GetAll();

        public IDictionary<string, string> GetRange(ICollection<string> ids);

        public Task<KeyValuePair<string, string>?> Get(string id);

        public Task<T?> Delete(string id);
    }
}