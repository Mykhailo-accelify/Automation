namespace API.Models
{
    using DataAccess.Models.Identified;

    public class ClientOneNested : ClientPut
    {
        public ICollection<ProductIdentified> Products { get; set; }

        public ICollection<InfrastructureIdentified> Infrastructures { get; set; }

        public ICollection<ConfigurationIdentified> Configurations { get; set; }
    }
}
