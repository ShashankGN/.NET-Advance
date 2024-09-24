using JWT_Authentication_Authorization_own.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Authentication_Authorization_own.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [Authorize]
        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok("I'm authorised as User");
        }

        [Authorize(Roles =UserRoles.Admin)]
        [HttpGet("admin")]
        public IActionResult GetAdmin()
        {
            return Ok("I'm authorised as Admin");
        }
    }
}
