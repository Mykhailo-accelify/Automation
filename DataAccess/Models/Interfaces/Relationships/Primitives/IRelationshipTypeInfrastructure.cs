using DataAccess.Entities;

namespace DataAccess.Models.Interfaces.Relationships.Primitives;

public interface IRelationshipTypeInfrastructure
{
    public int TypeInfrastructureId { get; set; }

    public TypeInfrastructure TypeInfrastructure { get; set; }

}