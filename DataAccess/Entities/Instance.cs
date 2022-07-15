using DataAccess.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class Instance : IInstance
{
    public int Id { get; set; }
    
    [StringLength(50)]
    public string Name { get; set; }
    
    public string Endpoint { get; set; }
    
    public string Secret { get; set; }

    public int TypeInstanceId { get; set; }
    
    public virtual TypeInstance TypeInstance { get; set; }

    public virtual ICollection<Infrastructure> Infrastructures { get; set; }
}