using BooksAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenManager _jwtTokenManager;
        public AuthController(IJwtTokenManager jwtTokenManager)
        {
            _jwtTokenManager = jwtTokenManager;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Login([FromBody] UserCredential userCredential)
        {
            //Here we implement the logic for the login. 
            //If the login is successful, you can retrive the
            //

            if (userCredential == null || string.IsNullOrEmpty(userCredential.UserName) || string.IsNullOrEmpty(userCredential.Password))
            {
                return BadRequest("Invalid credentials.");
            }



            //if (isLoginSuccess)
            //{
            //    var token = _jwtTokenManager.Authenticate(userCredential.UserName, userCredential.Password);
            //    return Ok(token);
            //}
            //return Unauthorized();

            if (IsLoginSuccess(userCredential.UserName, userCredential.Password))
            {
                var token = _jwtTokenManager.Authenticate(userCredential.UserName, userCredential.Password);
                return Ok(token);

            }

            return Unauthorized();
        }

        private static bool IsLoginSuccess(string username, string password)
        {
            // This method should validate the username and password
            // For demonstration purposes, we'll use hardcoded values
            // In a real application, validate against a database or user store

            return username == "testuser" && password == "testpassword";
        }


    }
}
