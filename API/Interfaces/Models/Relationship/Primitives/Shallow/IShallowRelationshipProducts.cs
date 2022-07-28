using API.Models.Shallow.Primitives;

namespace API.Interfaces.Models.Relationship.Primitives.Shallow;

public interface IShallowRelationshipProducts
{
    public ICollection<ILonelyProduct> Products { get; set; }

}