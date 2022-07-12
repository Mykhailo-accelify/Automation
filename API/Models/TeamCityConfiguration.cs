namespace API.Models
{
    public class TeamCityConfiguration
    {
        public string SiteName { get; set; }

        public string ImportToolSiteName { get; set; }

        public string Domain { get; set; }

        public string StateAbbreviation { get; set; }

        public string[] Products { get; set; }

        public ICollection<IIS> SiteIISs { get; set; }

        public ICollection<IIS> ImportToolIISs { get; set; }

        public RabbitMQ RabbitMQ { get; set; }

        public string LoadBalancerWeb { get; set; }

        public string LoadBalancerImport { get; set; }

        public string FSXDNS { get; set; }

        public string DatabaseListenerName { get; set; }

        public string DatabaseName { get; set; }
        
        public string EnvironmentFolder { get; set; }

        public string FSXFolder { get; set; }        
    }
}