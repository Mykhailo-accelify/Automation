namespace API.Models.TeamCity
{
    public class TeamCityDeleteConfiguration
    {
        public string Domain { get; set; }

        public ICollection<ClientTC> Clients { get; set; }

        public ICollection<InfrastructureTC> Infrastructures { get; set; } = new List<InfrastructureTC>();

    }

    public class ClientTC
    {
        public string? DistrictName { get; set; }

        public string? ImportSite { get; set; }

    }

    public class InfrastructureTC
    {
        public string Name { get; set; }

        public ICollection<ClientTC> Clients { get; set; }

        public IISGroup IIS { get; set; }

        public FSXTC FSX { get; set; }

        public RabbitMQTC RabbitMQ { get; set; }

    }

    public class IISGroup
    {
        public IEnumerable<IISTC> Import { get; set; }

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
}
