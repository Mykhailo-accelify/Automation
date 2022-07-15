using DataAccess.Models.Interfaces;
using DataAccess.Models.Interfaces.Relationships;
using DataAccess.Models.Interfaces.Relationships.Primitives;

namespace DataAccess.Entities;

public class TypeInfrastructure : IType, IRelationshipInfrastructures
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<Infrastructure> Infrastructures { get; set; }
}