namespace API.Controllers
{
    using API.Athentication;
    using API.Interfaces.Services;
    using DataAccess.Entities;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [ServiceAuthorize]
    [Route("api/[controller]")]
    public class APIConstantController : ControllerBase
    {
        private readonly IConstantService<APIConstant> service;

        public APIConstantController(IConstantService<APIConstant> service)
        {
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDictionary<string, string>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var apiConstant = await service.GetAll();
            if (!apiConstant.Any())
            {
                return NotFound();
            }

            return Ok(apiConstant);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(KeyValuePair<string, string>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string id)
        {
            var apiConstant = await service.Get(id);
            if (apiConstant is null)
            {
                return NotFound();
            }

            return Ok(apiConstant);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(APIConstant))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] APIConstant value)
        {
            var apiConstant = await service.Create(value);
            if (apiConstant is null)
            {
                return BadRequest($"Error during {nameof(APIConstant)} creation, check log");
            }

            return Ok(apiConstant);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(APIConstant))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] APIConstant value)
        {
            var apiConstant = await service.Update(value);
            if (apiConstant is null)
            {
                return BadRequest($"Error during {nameof(APIConstant)} updating, check log");
            }

            return Ok(apiConstant);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(APIConstant))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string id)
        {
            var apiConstant = await service.Delete(id);
            if (apiConstant is null)
            {
                return BadRequest($"Error during {nameof(APIConstant)} deleting, check log");
            }

            return Ok(apiConstant);
        }
    }
}