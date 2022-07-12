namespace API.Comparers
{
    using DataAccess.Entities;
    using System.Diagnostics.CodeAnalysis;

    public class ClientComparer : IEqualityComparer<Client>
    {
        public bool Equals(Client? x, Client? y)
        {
            return x?.Id == y?.Id;
        }

        public int GetHashCode([DisallowNull] Client obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
