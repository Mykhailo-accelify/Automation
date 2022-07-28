using API.Models.Shallow.Primitives;

namespace API.Interfaces.Models.Relationship.Primitives.Shallow;

public interface IShallowRelationshipState
{
    public ILonelyState State { get; set; }

}