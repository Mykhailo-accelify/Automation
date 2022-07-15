using DataAccess.Entities;

namespace DataAccess.Models.Interfaces.Relationships.Primitives;

public interface IRelationshipTypeInstance
{
    public int TypeInstanceId { get; set; }
    
    public TypeInstance TypeInstance { get; set; }
}