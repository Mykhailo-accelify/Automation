using API.Models.Shallow.Primitives;

namespace API.Models.Shallow.Relationship.Primitives;

public interface IShallowRelationshipProducts
{
    public ICollection<ILonelyProduct> Products { get; set; }

}