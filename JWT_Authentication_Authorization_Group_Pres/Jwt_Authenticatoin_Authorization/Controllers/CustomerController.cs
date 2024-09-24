using Jwt_Authenticatoin_Authorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Authenticatoin_Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok("This is authorized and user can access it");
        }

        [Authorize(Roles=UserRoles.Admin)]
        [HttpGet]
        [Route("admin")]

        public IActionResult GetAdmin()
        {
            return Ok("This is authorized and only admin can access it");
        }
    }
}
