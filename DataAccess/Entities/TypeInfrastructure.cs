using DataAccess.Models.Interfaces;

namespace DataAccess.Entities;

public class TypeInfrastructure : ITypeInfrastructure
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<Infrastructure> Infrastructures { get; set; }
}