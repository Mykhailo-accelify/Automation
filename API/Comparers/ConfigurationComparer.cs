namespace API.Comparers
{
    using DataAccess.Entities;
    using System.Diagnostics.CodeAnalysis;

    public class ConfigurationComparer : IEqualityComparer<Configuration>
    {
        public bool Equals(Configuration? x, Configuration? y)
        {
            return x?.Id == y?.Id;
        }

        public int GetHashCode([DisallowNull] Configuration obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
