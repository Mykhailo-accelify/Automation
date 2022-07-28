using API.Interfaces.Models.Relationship.Primitives.Create;

namespace API.Interfaces.Models.Relationship.Create;

public interface ICreateInfrastructureRelationships :
    ICreateRelationshipTypeInfrastructure,
    ICreateRelationshipClients,
    ICreateRelationshipInstances,
    ICreateRelationshipInfrastructureVariables
{
    
}