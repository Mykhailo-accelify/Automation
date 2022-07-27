using API.Models.Shallow.Primitives;
using API.Models.Shallow.Relationship;

namespace API.Models.Shallow;

public interface IShallowInstance : ILonelyInstance, IInstanceShallowRelationship
{
    
}