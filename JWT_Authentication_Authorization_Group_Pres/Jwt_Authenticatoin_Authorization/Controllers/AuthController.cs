using Jwt_Authenticatoin_Authorization.Contracts;
using Jwt_Authenticatoin_Authorization.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Authenticatoin_Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _auth;
        public AuthController(IAuth auth)
        {
            _auth = auth;      
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var user = await _auth.CheckLoginCred(model);
            if (user != null)
            {
                return Ok(user);
            }
            return Unauthorized();
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
           var userExists=await _auth.UserRegister(model);
            if (userExists.Status == "Error")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, userExists);
            }
            return Ok(userExists);
        }
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] Register model)
        {
            var userExists=await _auth.AdminRegister(model);
            if(userExists.Status == "Error")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, userExists);
            }
            return Ok(userExists);

        }

    }
}
