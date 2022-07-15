using DataAccess.Entities;

namespace DataAccess.Models.Interfaces.Relationships.Primitives;

public interface IRelationshipInstances
{
    public ICollection<Instance> Instances { get; set; }

}