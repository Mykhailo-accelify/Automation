namespace API.Models.Old
{
    using DataAccess.Models.Identified;

    public class InfrastructurePut : InfrastructureIdentified
    {
        public ICollection<InstanceIdentified> Instances { get; set; }

        public ICollection<ClientIdentified> Clients { get; set; }
    }
}
