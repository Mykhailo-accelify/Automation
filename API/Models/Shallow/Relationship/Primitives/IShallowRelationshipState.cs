using API.Models.Shallow.Primitives;

namespace API.Models.Shallow.Relationship.Primitives;

public interface IShallowRelationshipState
{
    public ILonelyState State { get; set; }

}