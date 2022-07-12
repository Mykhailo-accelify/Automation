namespace DataAccess.Entities
{
    using DataAccess.Models.Identified;

    public class Configuration : ConfigurationIdentified
    {
        public virtual Client Client { get; set; }
    }
}
