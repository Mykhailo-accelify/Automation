using API.Models.Shallow.Primitives;
using API.Models.Shallow.Relationship;

namespace API.Models.Shallow;

public interface IShallowClient : ILonelyClient, IClientShallowRelationship
{

}