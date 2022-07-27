namespace API.Models.Old
{
    using DataAccess.Models.Identified;

    public class ConfigurationOneNested : ConfigurationIdentified
    {
        public ClientIdentified Client { get; set; }
    }
}
