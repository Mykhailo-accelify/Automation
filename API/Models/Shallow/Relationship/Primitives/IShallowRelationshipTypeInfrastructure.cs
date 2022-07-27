using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Shallow.Relationship.Primitives;

public interface IShallowRelationshipTypeInfrastructure
{
    public IType TypeInfrastructure { get; set; }

}