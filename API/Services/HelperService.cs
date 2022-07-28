namespace API.Services
{
    using API.Interfaces.Services;

    public class HelperService : IHelperService
    {
        public void UpdateRelationCollection<T>(ICollection<T>? first, ICollection<T>? second, IEqualityComparer<T> comparer)
        {
            if (first is null) first = new List<T>();
            if (second is null) second = new List<T>();
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
