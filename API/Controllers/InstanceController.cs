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
    public class InstanceController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICRUDService<Instance> service;

        public InstanceController(IMapper mapper, ICRUDService<Instance> service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<InstanceOneNested>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var instances = await service.GetAll();
            if (!instances.Any())
            {
                return NotFound();
            }

            return Ok(mapper.Map<IEnumerable<InstanceOneNested>>(instances));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InstanceOneNested))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.Get(id);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<InstanceOneNested>(result));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InstanceOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] InstanceBase item)
        {
            var result = await service.Create(mapper.Map<Instance>(item));
            if (result is null)
            {
                return BadRequest($"Error during {nameof(Instance)} creation, check log");
            }

            var instance = mapper.Map<InstanceOneNested>(result);
            return CreatedAtAction(nameof(Get), new { id = instance.Id }, instance);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InstanceOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] InstancePut item)
        {
            var instance = await service.Update(mapper.Map<Instance>(item));
            if (instance is null)
            {
                return BadRequest($"Error during {nameof(Instance)} updating, check log");
            }

            return Ok(mapper.Map<InstanceOneNested>(instance));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InstanceOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.Delete(id);
            if (result is null)
            {
                return BadRequest($"Error during {nameof(Infrastructure)} deleting, check log");
            }

            return Ok(mapper.Map<InstanceOneNested>(result));
        }
    }
}