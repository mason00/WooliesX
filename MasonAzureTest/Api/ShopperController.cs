using System.Threading.Tasks;
using MasonAzureTest.Interfaces;
using MasonAzureTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasonAzureTest.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopperController : ControllerBase
    {
        private readonly IShopperService _service;
        public ShopperController(IShopperService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetHistory(string token)
        {
            var result = await _service.GetShopperHistory(token);
            return Ok(result);
        }

        [HttpGet]
        [Route("user")]
        public ActionResult GetUser()
        {
            return Ok(new
            {
                Name = "Mason Hu",
                Token = "1f2c0c32-1aa6-40b2-b523-106868028331"
            });
        }
    }
}