namespace DataAccess.Models.Identified
{
    using DataAccess.Models.Base;

    public class ConfigurationIdentified : ConfigurationBase, IIdentified
    {
        public int Id { get; set; }
    }
}
