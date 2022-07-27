namespace API.Models.TeamCity
{
    public class InfrastructureTC
    {
        public string Name { get; set; }

        public string Domain { get; set; }

        public string PropertyFolder { get; set; }

        public ICollection<ClientTC> Clients { get; set; } = new List<ClientTC>();

        public IISGroup IIS { get; set; }

        public FSXTC FSX { get; set; }

        public RabbitMQTC RabbitMQ { get; set; }

        public LoadBalancerGroupTC LB { get; set; }

    }

    public class ClientTC
    {
        public string? Name { get; set; }

        public string? WebSite { get; set; }

        public string? ImportSite { get; set; }

    }

    public class IISGroup
    {
        public IEnumerable<IISTC>? Import { get; set; }

        public IEnumerable<IISTC> Web { get; set; }

    }
    public class IISTC
    {
        public string? Host { get; set; }

    }

    public class FSXTC
    {
        public string? Host { get; set; }

        public string? Folder { get; set; }

    }

    public class RabbitMQTC
    {
        public string? URL { get; set; }

    }

    public class LoadBalancerGroupTC
    {
        public LoadBalancerTC Web { get; set; }

        public LoadBalancerTC? Import { get; set; }

    }

    public class LoadBalancerTC
    {
        public string? URL { get; set; }

    }
}
