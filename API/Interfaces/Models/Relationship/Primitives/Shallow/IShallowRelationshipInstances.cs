using API.Models.Shallow.Primitives;

namespace API.Interfaces.Models.Relationship.Primitives.Shallow;

public interface IShallowRelationshipInstances
{
    public ICollection<ILonelyInstance> Instances { get; set; }

}