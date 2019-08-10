using Microsoft.AspNetCore.Mvc;

namespace MasonAzureTest.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult Test()
        {
            return Ok("OK");
        }
    }
}