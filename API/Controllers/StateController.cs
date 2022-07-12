namespace API.Controllers
{
    using API.Interfaces;
    using AutoMapper;
    using DataAccess.Entities;
    using Microsoft.AspNetCore.Mvc;
    using DataAccess.Models.Base;
    using API.Athentication;

    [ApiController]
    [ServiceAuthorize]
    [Route("api/[controller]")]
    public class StateController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IStateService service;

        public StateController(IStateService service, IMapper mapper)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<State>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var states = await service.GetAll();
            if (!states.Any())
            {
                return NotFound();
            }

            return Ok(states);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(State))]
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
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(State))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] StateBase item)
        {
            var state = await service.Create(mapper.Map<State>(item));
            if (state is null)
            {
                return BadRequest($"Error during {nameof(State)} creation, check log");
            }

            return CreatedAtAction(nameof(Get), new { id = state.Id }, state);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(State))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] State item)
        {
            var state = await service.Update(item);
            if (state is null)
            {
                return BadRequest($"Error during {nameof(State)} updating, check log");
            }

            return Ok(state);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(State))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.Delete(id);
            if (result is null)
            {
                return BadRequest($"Error during {nameof(State)} deleting, check log");
            }

            return Ok(result);
        }
    }
}