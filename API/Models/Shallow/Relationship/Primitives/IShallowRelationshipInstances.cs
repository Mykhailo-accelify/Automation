using API.Models.Shallow.Primitives;

namespace API.Models.Shallow.Relationship.Primitives;

public interface IShallowRelationshipInstances
{
    public ICollection<ILonelyInstance> Instances { get; set; }

}