namespace API.Models
{
    using DataAccess.Models.Identified;

    public class InstancePut : InstanceIdentified
    {
        public ICollection<InfrastructureIdentified> Infrastructures { get; set; }
    }
}
