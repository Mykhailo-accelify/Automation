namespace API.Comparers
{
    using DataAccess.Entities;
    using System.Diagnostics.CodeAnalysis;

    public class InstanceComparer : IEqualityComparer<Instance>
    {
        public bool Equals(Instance? x, Instance? y)
        {
            return x?.Id == y?.Id;
        }

        public int GetHashCode([DisallowNull] Instance obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
