namespace API.Models
{
    using DataAccess.Models.Identified;

    public class ConfigurationOneNested : ConfigurationIdentified
    {
        public ClientIdentified Client { get; set; }
    }
}
