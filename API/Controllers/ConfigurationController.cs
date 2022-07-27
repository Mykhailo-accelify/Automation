namespace API.Controllers
{
    using API.Athentication;
    using API.Interfaces;
    using API.Models.Old;
    using AutoMapper;
    using DataAccess.Entities;
    using DataAccess.Models.Base;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [ServiceAuthorize]
    [Route("api/[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICRUDService<Configuration> service;

        public ConfigurationController(IMapper mapper, ICRUDService<Configuration> service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ConfigurationOneNested>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var configurations = await service.GetAll();
            if (!configurations.Any())
            {
                return NotFound();
            }

            return Ok(mapper.Map<IEnumerable<ConfigurationOneNested>>(configurations));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConfigurationOneNested))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.Get(id);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ConfigurationOneNested>(result));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ConfigurationOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ConfigurationBase item)
        {
            var result = await service.Create(mapper.Map<Configuration>(item));
            if (result is null)
            {
                return BadRequest($"Error during {nameof(Configuration)} creation, check log");
            }

            var configuration = mapper.Map<ConfigurationOneNested>(result);
            return CreatedAtAction(nameof(Get), new { id = configuration.Id }, configuration);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConfigurationOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] ConfigurationBase item)
        {
            var result = await service.Update(mapper.Map<Configuration>(item));
            if (result is null)
            {
                return BadRequest($"Error during {nameof(Configuration)} updating, check log");
            }

            return Ok(mapper.Map<ConfigurationOneNested>(result));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConfigurationOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.Delete(id);
            if (result is null)
            {
                return BadRequest($"Error during {nameof(Configuration)} deleting, check log");
            }

            return Ok(mapper.Map<ConfigurationOneNested>(result));
        }
    }
}