namespace DataAccess.Entities
{
    using DataAccess.Models.Identified;
    using System.ComponentModel.DataAnnotations;

    public class Infrastructure : InfrastructureIdentified
    {
        [StringLength(50)]
        public new string Name { get; set; }

        [StringLength(20)]
        public new string ConfigurationFolder { get; set; }

        //[ForeignKey(nameof(State))]
        //[Column(nameof(InfrastructureStateId))]
        //public virtual int InfrastructureStateId { get; set; }
        //[ForeignKey("StateId")]
        public virtual State State { get; set; }

        public virtual ICollection<Instance> Instances { get; set; }

        public virtual ICollection<InfrastructureVariable> InfrastrucureVariables { get; set; }

        public ICollection<Client> Clients { get; set; }

        public virtual TypeInfrastructure TypeInfrastructure { get; set; }
    }
}
