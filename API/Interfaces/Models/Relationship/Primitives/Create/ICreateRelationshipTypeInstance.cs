using DataAccess.Models.Interfaces.Primitives;

namespace API.Interfaces.Models.Relationship.Primitives.Create;

public interface ICreateRelationshipTypeInstance
{
    public INamed TypeInstance { get; set; }

}