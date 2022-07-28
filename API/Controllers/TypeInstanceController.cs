namespace API.Controllers
{
    using API.Athentication;
    using API.Interfaces.Services;
    using API.Models.Old;
    using AutoMapper;
    using DataAccess.Entities;
    using DataAccess.Models.Base;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [ServiceAuthorize]
    [Route("api/[controller]")]
    public class TypeInstanceController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICRUDService<TypeInstance> service;

        public TypeInstanceController(IMapper mapper, ICRUDService<TypeInstance> service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TypeInstanceOneNested>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var typesInstances = await service.GetAll();
            if (!typesInstances.Any())
            {
                return NotFound();
            }

            return Ok(mapper.Map<IEnumerable<TypeInstanceOneNested>>(typesInstances));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TypeInstanceOneNested))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.Get(id);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TypeInstanceOneNested>(result));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TypeInstanceOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] TypeInstanceBase item)
        {
            var result = await service.Create(mapper.Map<TypeInstance>(item));
            if (result is null)
            {
                return BadRequest($"Error during {nameof(TypeInstance)} creation, check log");
            }

            var typeInstance = mapper.Map<TypeInstanceOneNested>(result);
            return CreatedAtAction(nameof(Get), new { id = typeInstance.Id }, typeInstance);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TypeInstanceOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] TypeInstanceOneNested item)
        {
            var typeInstance = await service.Update(mapper.Map<TypeInstance>(item));
            if (typeInstance is null)
            {
                return BadRequest($"Error during {nameof(TypeInstance)} updating, check log");
            }

            return Ok(mapper.Map<TypeInstanceOneNested>(typeInstance));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TypeInstanceOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.Delete(id);
            if (result is null)
            {
                return BadRequest($"Error during {nameof(TypeInstance)} deleting, check log");
            }

            return Ok(mapper.Map<TypeInstanceOneNested>(result));
        }
    }
}