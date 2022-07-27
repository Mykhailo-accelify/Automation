using DataAccess.Models.Interfaces;

namespace DataAccess.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class InfrastructureVariable : IInfrastructureVariables
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; set; }

        public string Value { get; set; }
        
        public ICollection<Infrastructure> Infrastructures { get; set; }
    }
}
