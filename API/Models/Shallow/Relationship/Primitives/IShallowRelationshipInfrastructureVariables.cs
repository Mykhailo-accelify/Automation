using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Shallow.Relationship.Primitives;

public interface IShallowRelationshipInfrastructureVariables
{
    public ICollection<IKeyValue> InfrastructureVariables { get; set; }

}