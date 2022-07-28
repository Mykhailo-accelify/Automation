using API.Interfaces.Models.Relationship.Primitives.Shallow;

namespace API.Interfaces.Models.Relationship.Shallow;

public interface IInfrastructureShallowRelationship :
    IShallowRelationshipTypeInfrastructure,
    IShallowRelationshipClients,
    IShallowRelationshipInstances,
    IShallowRelationshipInfrastructureVariables
{

}