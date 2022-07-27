using DataAccess.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public sealed class Infrastructure : IInfrastructure
{
    public int Id { get; set; }
    
    [StringLength(50)]
    public new string Name { get; set; }

    public int MaxStudents { get; set; }

    [StringLength(20)]
    public new string ConfigurationFolder { get; set; }
    
    public int TypeInfrastructureId { get; set; }
    
    public TypeInfrastructure TypeInfrastructure { get; set; }
    
    public ICollection<InfrastructureVariable> InfrastructureVariables { get; set; }
    
    public ICollection<Instance> Instances { get; set; }

    public ICollection<Client> Clients { get; set; }
}