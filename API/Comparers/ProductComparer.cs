namespace API.Comparers
{
    using DataAccess.Entities;
    using System.Diagnostics.CodeAnalysis;

    public class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
            return x?.Id == y?.Id;
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
