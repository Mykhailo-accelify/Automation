using DataAccess.Models.Interfaces.Relationships.Primitives;

namespace DataAccess.Models.Interfaces.Relationships;

public interface IInfrastructureRelationships : IRelationshipTypeInfrastructure,
    IRelationshipClients,
    IRelationshipInstances,
    IRelationshipState,
    IRelationshipInfrastructureVariables
{
    
}