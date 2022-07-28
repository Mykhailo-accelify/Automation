using DataAccess.Models.Interfaces.Primitives;

namespace API.Interfaces.Models.Relationship.Primitives.Shallow;

public interface IShallowRelationshipTypeInfrastructure
{
    public IType TypeInfrastructure { get; set; }

}