namespace DataAccess.Models.Identified
{
    using DataAccess.Models.Base;

    public class TypeInfrastructureIdentified : TypeInfrastructureBase, IIdentified
    {
        public int Id { get; set; }
    }
}
