using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MiniApp1.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {


        [Authorize(Policy = "BirthDayPolicy")]
        [Authorize(Roles = "admin", Policy = "CityPolicy")]

        [HttpGet]
        public IActionResult GetStock()
        {
            var userName = HttpContext.User.Identity.Name;
            var userId = User.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier);

            return Ok($"Stok bilgileri => UserName : {userName} - UserId : {userId}");
        }
    }
}
