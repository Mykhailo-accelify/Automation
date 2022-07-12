namespace DataAccess.Entities
{
    using DataAccess.Models.Identified;
    using System.ComponentModel.DataAnnotations;

    public class Instance : InstanceIdentified
    {
        [StringLength(50)]
        public override string Name { get; set; }

        public virtual ICollection<Infrastructure> Infrastructures { get; set; }

        public virtual TypeInstance TypeInstance { get; set; }
    }
}
