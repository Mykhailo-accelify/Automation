namespace API.Interfaces
{
    using API.Models;
    using System.Xml;

    public interface IConfigService
    {
        public Task<XmlDocument?> GenerateCustomerEnvironmentConfig(int clientId, string infrastructureName);

        public Task<XmlDocument?> GenerateState504Config(int clientId, string infrastructureName);

        public Task<XmlDocument?> GenerateStateConfig(int clientId, string infrastructureName);

        public Task<TeamCityConfiguration?> GenerateTeamCityConfiguration(int clientId, string infrastructureName);

        public Task<XmlDocument?> GenerateCommonEnvironmentConfig(string infrastructureName);

        public Task<TeamCityConfiguration?> GenerateTeamCityDeleteConfiguration(IEnumerable<string> clients);
    }
}
