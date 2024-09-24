using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAssessmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShashankController : ControllerBase
    {

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Shashank");
        }
    }
}
