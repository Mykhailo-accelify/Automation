namespace API.Controllers
{
    using API.Athentication;
    using API.Interfaces.Services;
    using DataAccess.Entities;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [ServiceAuthorize]
    [Route("api/[controller]")]
    public class InfrastructureVariablesController : ControllerBase
    {
        private readonly IConstantService<InfrastructureVariable> service;

        public InfrastructureVariablesController(IConstantService<InfrastructureVariable> service)
        {
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDictionary<string, string>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var infrastructureVariables = await service.GetAll();
            if (!infrastructureVariables.Any())
            {
                return NotFound();
            }

            return Ok(infrastructureVariables);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(KeyValuePair<string, string>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string id)
        {
            var infrastructureVariable = await service.Get(id);
            if (infrastructureVariable is null)
            {
                return NotFound();
            }

            return Ok(infrastructureVariable);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InfrastructureVariable))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] InfrastructureVariable value)
        {
            var infrastructureVariable = await service.Create(value);
            if (infrastructureVariable is null)
            {
                return BadRequest($"Error during {nameof(InfrastructureVariable)} creation, check log");
            }

            return Ok(infrastructureVariable);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfrastructureVariable))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] InfrastructureVariable value)
        {
            var infrastructureVariable = await service.Update(value);
            if (infrastructureVariable is null)
            {
                return BadRequest($"Error during {nameof(InfrastructureVariable)} updating, check log");
            }
            return Ok(infrastructureVariable);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfrastructureVariable))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string id)
        {
            var infrastructureVariable = await service.Delete(id);
            if (infrastructureVariable is null)
            {
                return BadRequest($"Error during {nameof(InfrastructureVariable)} deleting, check log");
            }

            return Ok(infrastructureVariable);
        }
    }
}