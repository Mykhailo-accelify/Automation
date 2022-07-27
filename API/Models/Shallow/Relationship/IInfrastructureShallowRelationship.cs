using API.Models.Shallow.Relationship.Primitives;

namespace API.Models.Shallow.Relationship;

public interface IInfrastructureShallowRelationship :
    IShallowRelationshipTypeInfrastructure,
    IShallowRelationshipClients,
    IShallowRelationshipInstances,
    IShallowRelationshipInfrastructureVariables
{
    
}