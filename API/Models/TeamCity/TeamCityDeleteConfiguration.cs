namespace API.Models.TeamCity
{
    public class TeamCityDeleteConfiguration
    {
        public string Domain { get; set; }

        public ICollection<Client> Clients { get; set; }

        public ICollection<Infrastructure> Infrastructures { get; set; }

    }

    public class Client
    {
        public string DistrictName { get; set; }

        public string ImportSite { get; set; }

    }

    public class Infrastructure
    {
        public ICollection<string> Clients { get; set; }

        public IISGroup IIS { get; set; }

        public FSX FSX { get; set; }

        public RabbitMQ RabbitMQ { get; set; }

    }

    public class IISGroup
    {
        public IIS Import { get; set; }

        public IIS Web { get; set; }

    }
    public class IIS
    {
        public string Host { get; set; }

    }

    public class FSX
    {
        public string Host { get; set; }

        public string Folder { get; set; }

    }

    public class RabbitMQ
    {
        public string URL { get; set; }

    }
}
