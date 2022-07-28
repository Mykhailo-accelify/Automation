namespace API.Interfaces.Services
{
    public interface IHelperService
    {
        void UpdateRelationCollection<T>(ICollection<T> first, ICollection<T> second, IEqualityComparer<T> comparer);
    }
}