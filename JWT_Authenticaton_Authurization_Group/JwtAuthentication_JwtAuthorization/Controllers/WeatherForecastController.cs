using JwtAuthentication_JwtAuthorization.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication_JwtAuthorization.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("hi You are authorised");
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        [Route("admin")]

        public IActionResult GetAdmin()
        {
            return Ok("I'm from admin access");
        }
    }
}
