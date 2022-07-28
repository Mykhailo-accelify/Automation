using DataAccess.Models.Interfaces.Primitives;

namespace API.Interfaces.Models.Relationship.Primitives.Shallow;

public interface IShallowRelationshipInfrastructureVariables
{
    public ICollection<IKeyValue> InfrastructureVariables { get; set; }

}