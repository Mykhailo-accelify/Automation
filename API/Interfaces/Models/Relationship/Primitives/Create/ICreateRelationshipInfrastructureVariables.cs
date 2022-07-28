using DataAccess.Models.Interfaces.Primitives;

namespace API.Interfaces.Models.Relationship.Primitives.Create;

public interface ICreateRelationshipInfrastructureVariables
{
    public ICollection<INamed> InfrastructureVariables { get; set; }

}