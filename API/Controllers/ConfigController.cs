namespace API.Controllers
{
    using API.Athentication;
    using API.Interfaces;
    using API.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    //[TeamCityAuthorize]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService configService;

        public ConfigController(IConfigService configService)
        {
            this.configService = configService;
        }

        [HttpGet("env/{clientId}/{infrastructureName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetEnv(int clientId, string infrastructureName)
        {
            var result = await configService.GenerateCustomerEnvironmentConfig(clientId, infrastructureName);
            if (result is null)
            {
                return BadRequest($"Error during environment configuration generation, check log");
            }

            return Ok(result.InnerXml);
        }

        [HttpGet("state504/{clientId}/{infrastructureName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get504State(int clientId, string infrastructureName)
        {
            var result = await configService.GenerateState504Config(clientId, infrastructureName);
            if (result is null)
            {
                return BadRequest($"Error during state 504 configuration generation, check log");
            }

            return Ok(result?.InnerXml);
        }


        [HttpGet("state/{clientId}/{infrastructureName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetState(int clientId, string infrastructureName)
        {
            var result = await configService.GenerateStateConfig(clientId, infrastructureName);
            if (result is null)
            {
                return BadRequest($"Error during state configuration generation, check log");
            }

            return Ok(result?.InnerXml);
        }


        [HttpGet("common/{infrastructureName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCommonConfiguration(string infrastructureName)
        {
            var result = await configService.GenerateCommonEnvironmentConfig(infrastructureName);
            if (result is null)
            {
                return BadRequest($"Error during common configuration generation, check log");
            }

            return Ok(result?.InnerXml);
        }

        [HttpGet("tc/{clientId}/{infrastructureName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeamCityConfiguration))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTeamCityConfiguration(int clientId, string infrastructureName)
        {
            var result = await configService.GenerateTeamCityConfiguration(clientId, infrastructureName);
            if (result is null)
            {
                return BadRequest($"Error during TeamCity configuration generation, check log");
            }

            return Ok(result);
        }

        [HttpDelete("tc")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeamCityConfiguration))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTeamCityDeleteConfiguration([FromBody] IEnumerable<string> names)
        {
            var result = await configService.GenerateTeamCityDeleteConfiguration(names);
            if (result is null)
            {
                return BadRequest($"Error during TeamCity delete configuration generation, check log");
            }

            return Ok(result);
        }
    }
}