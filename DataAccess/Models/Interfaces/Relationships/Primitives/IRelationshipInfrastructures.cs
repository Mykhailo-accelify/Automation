using DataAccess.Entities;

namespace DataAccess.Models.Interfaces.Relationships.Primitives;

public interface IRelationshipInfrastructures
{
    public ICollection<Infrastructure> Infrastructures { get; set; }

}