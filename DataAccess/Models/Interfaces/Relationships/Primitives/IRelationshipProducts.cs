using DataAccess.Entities;

namespace DataAccess.Models.Interfaces.Relationships.Primitives;

public interface IRelationshipProducts
{
    public ICollection<Product> Products { get; set; }

}