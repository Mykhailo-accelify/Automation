using DataAccess.Models.Interfaces;

namespace DataAccess.Entities;

public class TypeInstance : ITypeInstance
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public virtual ICollection<Instance> Instances { get; set; }
}