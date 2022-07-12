namespace API.Controllers
{
    using API.Interfaces;
    using API.Models;
    using AutoMapper;
    using DataAccess.Entities;
    using Microsoft.AspNetCore.Mvc;
    using DataAccess.Models.Base;
    using API.Athentication;

    [ApiController]
    [ServiceAuthorize]
    [Route("api/[controller]")]
    public class InfrastructureController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IInfrastructureService service;

        public InfrastructureController(IMapper mapper, IInfrastructureService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        [TeamCityAuthorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<InfrastructureOneNested>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var infrastructures = await service.GetAll();
            if (!infrastructures.Any())
            {
                return NotFound();
            }

            return Ok(mapper.Map<IEnumerable<InfrastructureOneNested>>(infrastructures));
        }

        [HttpGet("name")]
        [TeamCityAuthorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<State>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNames()
        {
            var names = await service.GetNames();
            if (!names.Any())
            {
                return NotFound();
            }

            return Ok(names);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfrastructureOneNested))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.Get(id);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<InfrastructureOneNested>(result));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InfrastructureOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] InfrastructureBase item)
        {
            var result = await service.Create(mapper.Map<Infrastructure>(item));
            if  (result is null)
            {
                return BadRequest($"Error during {nameof(Infrastructure)} creation, check log");
            }

            var infrastructure = mapper.Map<InfrastructureOneNested>(result);
            return CreatedAtAction(nameof(Get), new { id = infrastructure.Id }, infrastructure);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfrastructureOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] InfrastructurePut item)
        {
            var infrastructure = await service.Update(mapper.Map<Infrastructure>(item));
            if (infrastructure is null)
            {
                return BadRequest($"Error during {nameof(Infrastructure)} updating, check log");
            }

            return Ok(mapper.Map<InfrastructureOneNested>(infrastructure));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfrastructureOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.Delete(id);
            if (result is null)
            {
                return BadRequest($"Error during {nameof(Infrastructure)} deleting, check log");
            }

            return Ok(mapper.Map<InfrastructureOneNested>(result));
        }

        [TeamCityAuthorize]
        [HttpGet("{clientId}/{environment}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfrastructureOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InfrastructureOneNested?>> Booking(int clientId, string environment)
        {
            var result = await service.Booking(clientId, environment);
            if (result is null)
            {
                return BadRequest($"Error during {nameof(Infrastructure)} book, check log");
            }

            return Ok(mapper.Map<InfrastructureOneNested>(result));
        }
    }
}