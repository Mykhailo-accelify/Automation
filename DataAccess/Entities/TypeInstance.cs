using DataAccess.Models.Interfaces;
using DataAccess.Models.Interfaces.Relationships.Primitives;

namespace DataAccess.Entities;

public class TypeInstance : IType, IRelationshipInstances
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public virtual ICollection<Instance> Instances { get; set; }
}