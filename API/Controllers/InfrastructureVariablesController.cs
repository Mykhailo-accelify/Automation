using API.Models.Shallow;
using AutoMapper;
using DataAccess.Entities;

namespace API.Controllers
{
    using API.Athentication;
    using API.Interfaces.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [ServiceAuthorize]
    [Route("api/[controller]")]
    public class ShallowInfrastructureVariablesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IConstantService<InfrastructureVariable> service;

        public ShallowInfrastructureVariablesController(IConstantService<InfrastructureVariable> service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDictionary<string, string>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var ShallowInfrastructureVariables = await service.GetAll();
            if (!ShallowInfrastructureVariables.Any())
            {
                return NotFound();
            }

            return Ok(ShallowInfrastructureVariables);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(KeyValuePair<string, string>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string id)
        {
            var ShallowInfrastructureVariable = await service.Get(id);
            if (ShallowInfrastructureVariable is null)
            {
                return NotFound();
            }

            return Ok(ShallowInfrastructureVariable);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ShallowInfrastructureVariable))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ShallowInfrastructureVariable value)
        {
            var ShallowInfrastructureVariable = await service.Create(mapper.Map<InfrastructureVariable>(value));
            if (ShallowInfrastructureVariable is null)
            {
                return BadRequest($"Error during {nameof(ShallowInfrastructureVariable)} creation, check log");
            }

            return Ok(ShallowInfrastructureVariable);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShallowInfrastructureVariable))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] ShallowInfrastructureVariable value)
        {
            var ShallowInfrastructureVariable = await service.Update(mapper.Map<InfrastructureVariable>(value));
            if (ShallowInfrastructureVariable is null)
            {
                return BadRequest($"Error during {nameof(ShallowInfrastructureVariable)} updating, check log");
            }
            return Ok(ShallowInfrastructureVariable);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShallowInfrastructureVariable))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string id)
        {
            var ShallowInfrastructureVariable = await service.Delete(id);
            if (ShallowInfrastructureVariable is null)
            {
                return BadRequest($"Error during {nameof(ShallowInfrastructureVariable)} deleting, check log");
            }

            return Ok(ShallowInfrastructureVariable);
        }
    }
}