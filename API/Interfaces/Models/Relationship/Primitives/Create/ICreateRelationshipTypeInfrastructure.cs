using DataAccess.Models.Interfaces.Primitives;

namespace API.Interfaces.Models.Relationship.Primitives.Create;

public interface ICreateRelationshipTypeInfrastructure
{
    public INamed TypeInfrastructure { get; set; }

}