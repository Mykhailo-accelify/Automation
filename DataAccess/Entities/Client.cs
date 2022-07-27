namespace DataAccess.Entities
{
    using DataAccess.Models.Identified;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Client")]
    public class Client : ClientIdentified
    {
        [StringLength(50)]
        public override string Name { get; set; }

        [StringLength(50)]
        public override string Abbreviation { get; set; }

        //[ForeignKey(nameof(ClientState))]
        //[Column(nameof(ClientStateId))]
        //public virtual int ClientStateId { get; set; }

        //[ForeignKey("StateId")]
        public virtual State State { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public ICollection<Infrastructure> Infrastructures { get; set; }

        public virtual ICollection<Configuration> Configurations { get; set; }
    }
}
