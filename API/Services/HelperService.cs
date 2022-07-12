namespace API.Services
{
    using API.Interfaces;

    public class HelperService : IHelperService
    {
        public void UpdateRelationCollection<T>(ICollection<T> first, ICollection<T> second, IEqualityComparer<T> comparer)
        {
            foreach (var entity in first.Except(second, comparer))
            {
                first.Remove(entity);
            }
            foreach (var entity in second.Except(first, comparer))
            {
                first.Add(entity);
            }
        }
    }
}
