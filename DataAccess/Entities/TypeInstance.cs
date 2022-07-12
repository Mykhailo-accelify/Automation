namespace DataAccess.Entities
{
    using DataAccess.Models.Identified;

    public class TypeInstance : TypeInstanceIdentified
    {
        public virtual ICollection<Instance> Instances { get; set; }
    }
}