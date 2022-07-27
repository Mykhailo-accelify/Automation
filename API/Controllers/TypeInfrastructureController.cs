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
    public class TypeInfrastructureController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICRUDService<TypeInfrastructure> service;

        public TypeInfrastructureController(IMapper mapper, ICRUDService<TypeInfrastructure> service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TypeInfrastructureOneNested>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var typesInfrastructures = await service.GetAll();
            if (!typesInfrastructures.Any())
            {
                return NotFound();
            }

            return Ok(mapper.Map<IEnumerable<TypeInfrastructureOneNested>>(typesInfrastructures));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TypeInfrastructureOneNested))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.Get(id);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TypeInfrastructureOneNested>(result));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TypeInfrastructureOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] TypeInfrastructureBase item)
        {
            var result = await service.Create(mapper.Map<TypeInfrastructure>(item));
            if (result is null)
            {
                return BadRequest($"Error during {nameof(TypeInfrastructure)} creation, check log");
            }

            var typeInfrastructure = mapper.Map<TypeInfrastructureOneNested>(result);
            return CreatedAtAction(nameof(Get), new { id = typeInfrastructure.Id }, typeInfrastructure);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TypeInfrastructureOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] TypeInfrastructureOneNested item)
        {
            var typeInfrastructure = await service.Update(mapper.Map<TypeInfrastructure>(item));
            if (typeInfrastructure is null)
            {
                return BadRequest($"Error during {nameof(TypeInfrastructure)} updating, check log");
            }

            return Ok(mapper.Map<TypeInfrastructureOneNested>(typeInfrastructure));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TypeInfrastructureOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.Delete(id);
            if (result is null)
            {
                return BadRequest($"Error during {nameof(TypeInfrastructure)} deleting, check log");
            }

            return Ok(mapper.Map<TypeInfrastructureOneNested>(result));
        }
    }
}