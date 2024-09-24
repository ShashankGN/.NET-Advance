using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Vehicle_management.Contracts;
using Vehicle_management.DTO;

namespace Vehicle_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        IVehicleRepo _vehicleRepo;
        public VehicleController(IVehicleRepo vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var vehiclelist = _vehicleRepo.GetAll();
            return Ok(vehiclelist);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] VehicleDTO vehicleDTO)
        {
            //var user = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var age = HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == "age")?.Value;
           
            var addedVehicle = _vehicleRepo.AddVehicle(vehicleDTO);
            return Ok(addedVehicle);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var deletedvehicle=_vehicleRepo.DeleteVehicle(id);
            if (deletedvehicle)
            {
                return Ok($"Vehicle with id {id} deleted successfully");
            }
            return NotFound($"vehicle with id {id} is not found");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var vehicle=_vehicleRepo.GetVehicleById(id);
            if(vehicle == null)
            {
                return NotFound($"vehicle with id {id} is not found");
            }
            return Ok(vehicle);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id,VehicleDTO vehicleDTO)
        {
            var vehicle= _vehicleRepo.UpdateVehicle(id,vehicleDTO);
            if (vehicle==null)
            {
                return NotFound($"vehicle with id {id} is not found");
            }
            return Ok(vehicle );
        }

        [HttpGet("token")]
        public IActionResult GetToken()
        {
            var token=_vehicleRepo.GetToken();
            return Ok(token);
        }

    }
}
