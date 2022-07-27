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
    public class ProductController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProductService service;

        public ProductController(IMapper mapper, IProductService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductOneNested>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var products = await service.GetAll();
            if (!products.Any())
            {
                return NotFound();
            }

            return Ok(mapper.Map<IEnumerable<ProductOneNested>>(products));
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductOneNested))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.Get(id);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ProductOneNested>(result));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProductBase item)
        {
            var result = await service.Create(mapper.Map<Product>(item));
            if (result is null)
            {
                return BadRequest($"Error during {nameof(Product)} creation, check log");
            }

            var product = mapper.Map<ProductOneNested>(result);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] ProductOneNested item)
        {
            var product = await service.Update(mapper.Map<Product>(item));
            if (product is null)
            {
                return BadRequest($"Error during {nameof(Product)} updating, check log");
            }

            return Ok(mapper.Map<ProductOneNested>(product));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductOneNested))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.Delete(id);
            if (result is null)
            {
                return BadRequest($"Error during {nameof(Product)} deleting, check log");
            }

            return Ok(mapper.Map<ProductOneNested>(result));
        }
    }
}