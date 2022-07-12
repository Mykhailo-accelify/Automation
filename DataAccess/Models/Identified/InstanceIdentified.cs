namespace DataAccess.Models.Identified
{
    using DataAccess.Models.Base;

    public class InstanceIdentified : InstanceBase, IIdentified
    {
        public int Id { get; set; }
    }
}
