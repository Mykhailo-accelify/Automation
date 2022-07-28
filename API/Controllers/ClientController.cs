using API.Models.Create;
using API.Models.Shallow;
using API.Athentication;
using API.Interfaces.Services;
using API.Models.Lonely;
using AutoMapper;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
//[ServiceAuthorize]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IClientService service;

    public ClientController(IMapper mapper, IClientService service)
    {
        this.mapper = mapper;
        this.service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LonelyClient>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        var clients = await service.GetAll();
        if (!clients.Any())
        {
            return NotFound();
        }

        return Ok(mapper.Map<IEnumerable<LonelyClient>>(clients));
    }

    [HttpGet("name/{name}")]
    //[TeamCityAuthorize]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShallowClient))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string name)
    {
        var client = await service.Get(name);
        if (client is null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<ShallowClient>(client));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShallowClient))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var client = await this.service.Get(id);
        if (client is null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<ShallowClient>(client));
    }

    [HttpPost]
    //[TeamCityAuthorize]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ShallowClient))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateClient item)
    {
        var result = await service.Create(mapper.Map<Client>(item));
        if (result is null)
        {
            return BadRequest($"Error during {nameof(Client)} creation, check log");
        }

        var client = mapper.Map<ShallowClient>(result);
        return CreatedAtAction(nameof(Get), new { id = client.Id }, client);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShallowClient))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put([FromBody] ShallowClient item)
    {
        var result = await service.Update(mapper.Map<Client>(item));
        if (result is null)
        {
            return BadRequest($"Error during {nameof(Client)} updating, check log");
        }

        return Ok(mapper.Map<ShallowClient>(result));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShallowClient))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await service.Delete(id);
        if (result is null)
        {
            return BadRequest($"Error during {nameof(Client)} deleting, check log");
        }

        return Ok(mapper.Map<ShallowClient>(result));
    }
}