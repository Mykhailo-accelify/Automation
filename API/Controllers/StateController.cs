using API.Models.Create;
using API.Models.Shallow;

namespace API.Controllers
{
    using AutoMapper;
    using DataAccess.Entities;
    using Microsoft.AspNetCore.Mvc;
    using API.Athentication;
    using API.Interfaces.Services;

    [ApiController]
    [ServiceAuthorize]
    [Route("api/[controller]")]
    public class ShallowStateController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IStateService service;

        public ShallowStateController(IStateService service, IMapper mapper)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ShallowState>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var ShallowStates = await service.GetAll();
            if (!ShallowStates.Any())
            {
                return NotFound();
            }

            return Ok(ShallowStates);
        }

        [HttpGet("name")]
        [TeamCityAuthorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ShallowState>))]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShallowState))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.Get(id);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ShallowState))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateState item)
        {
            var state = await service.Create(mapper.Map<State>(item));
            if (state is null)
            {
                return BadRequest($"Error during {nameof(state)} creation, check log");
            }

            return CreatedAtAction(nameof(Get), new { id = state.Id }, state);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShallowState))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] ShallowState item)
        {
            var state = mapper.Map<ShallowState>(await service.Update(mapper.Map<State>(item)));
            if (state is null)
            {
                return BadRequest($"Error during {nameof(state)} updating, check log");
            }

            return Ok(state);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShallowState))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.Delete(id);
            if (result is null)
            {
                return BadRequest($"Error during {nameof(ShallowState)} deleting, check log");
            }

            return Ok(result);
        }
    }
}