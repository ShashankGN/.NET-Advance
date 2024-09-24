﻿using Authenticat.Microservice.Authenticate;
using Authenticat.Microservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authenticat.Microservice.Controllers
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

        [HttpPost("Authenticate")]
        public IActionResult Login([FromBody] Login userCredential)
        {


            if (userCredential == null || string.IsNullOrEmpty(userCredential.UserName) || string.IsNullOrEmpty(userCredential.Password))
            {
                return BadRequest("Invalid credentials.");
            };

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
