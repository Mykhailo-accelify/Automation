namespace DataAccess.Entities
{
    using DataAccess.Models.Identified;

    public class TypeInfrastructure : TypeInfrastructureIdentified
    {
        public virtual ICollection<Infrastructure> Infrastructures { get; set; }
    }
}