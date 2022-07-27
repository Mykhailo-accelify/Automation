namespace API.Models.Old
{
    using DataAccess.Entities;
    using DataAccess.Models.Identified;

    public class TypeInstanceOneNested : TypeInstance
    {
        public new ICollection<InstanceIdentified> Instances { get; set; }
    }
}
