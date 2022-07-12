namespace API.Comparers
{
    using DataAccess.Entities;
    using System.Diagnostics.CodeAnalysis;

    public class InfrastructureComparer : IEqualityComparer<Infrastructure>
    {
        public bool Equals(Infrastructure? x, Infrastructure? y)
        {
            return x?.Id == y?.Id;
        }

        public int GetHashCode([DisallowNull] Infrastructure obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
