using DataAccess.Entities;

namespace DataAccess.Models.Interfaces.Relationships.Primitives;

public interface IRelationshipTypeInstance
{
    public TypeInstance TypeInstance { get; set; }

}