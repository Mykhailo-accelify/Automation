using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Shallow.Relationship.Primitives;

public interface IShallowRelationshipTypeInstance
{
    public IType TypeInstance { get; set; }

}