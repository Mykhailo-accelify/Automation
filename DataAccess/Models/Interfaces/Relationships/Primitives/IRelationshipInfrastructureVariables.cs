using DataAccess.Entities;

namespace DataAccess.Models.Interfaces.Relationships.Primitives;

public interface IRelationshipInfrastructureVariables
{
    public ICollection<InfrastructureVariable> InfrastructureVariables { get; set; }

}