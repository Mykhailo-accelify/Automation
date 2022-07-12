namespace API.Controllers
{
    using API.Athentication;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class TestAuthController : ControllerBase
    {
        [HttpGet]
        [TeamCityAuthorize]
        public async Task<IActionResult> Get()
        {
            return this.Ok();
        }
    }
}
