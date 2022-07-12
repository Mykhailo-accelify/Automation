namespace DataAccess.Models.Identified
{
    using DataAccess.Models.Base;

    public class InfrastructureIdentified : InfrastructureBase, IIdentified
    {
        public int Id { get; set; }
    }
}
