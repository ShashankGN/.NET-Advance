using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vehicle_management.Contracts;
using Vehicle_management.Data;
using Vehicle_management.DTO;
using Vehicle_management.Models;

namespace Vehicle_management.Repository
{
    public class VehicleRepo : IVehicleRepo
    {
        VehicleDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VehicleRepo(VehicleDbContext dbContext, IConfiguration configuration,IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public string AddVehicle(VehicleDTO vehicleDTO)
        {

            //added to store the user who has created the vehicle
             var user = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
            var age = _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == "age")?.Value;
            Vehicle obj = new()
            {
                RegNo = vehicleDTO.RegNo,
                Model = vehicleDTO.Model,
                ManufactureDate = vehicleDTO.ManufactureDate,
                CreatedBy =user
            };
            _dbContext.VehiclesMD.Add(obj);
            _dbContext.SaveChanges();
            return "Vehicle Added";

        }

        public bool DeleteVehicle(int id)
        {
            var vehicle= _dbContext.VehiclesMD.FirstOrDefault(x => x.Id == id);
            if (vehicle != null)
            {
                _dbContext.VehiclesMD.Remove(vehicle);
                _dbContext.SaveChanges();
                return true;
            }
            return false;   
        }

        public IEnumerable<VehicleDTO> GetAll()
        {
            List<VehicleDTO> list = new List<VehicleDTO>();
            foreach (var item in _dbContext.VehiclesMD)
            {
                list.Add(new VehicleDTO
                {
                    RegNo = item.RegNo,
                    Model = item.Model,
                    ManufactureDate = item.ManufactureDate
                });
            }
            return list;
        }

        public string GetToken()
        {
            //throw new Exception("Error while accessing the get request");
            //var authClaims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name, "Shashank"),
            //        new Claim(ClaimTypes.Role,"Admin"),
            //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),                   
            //    };
            //var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTAuth:SecretKey"]));
            //var token = new JwtSecurityToken(
            //    issuer: _configuration["JWTAuth:ValidIssuerURL"],
            //    audience: _configuration["JWTAuth:ValidAudienceURL"],
            //    expires: DateTime.Now.AddHours(1),
            //    claims: authClaims,
            //    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            //    );
            //var accessToken= new JwtSecurityTokenHandler().WriteToken(token);
            //return accessToken;

            var age = 30;
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"Shashank"),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim("age",age.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTAuth:SecretKey"]));
            var token=new JwtSecurityToken(
                issuer: _configuration["JWTAuth:ValidIssuerURL"],
                audience: _configuration["JWTAuth:ValidAudienceURL"],
                expires:DateTime.Now.AddHours(1),
                claims:authClaims,
                signingCredentials:new SigningCredentials(authSigningKey,SecurityAlgorithms.HmacSha256));
            var accessToken=new JwtSecurityTokenHandler().WriteToken(token);
            return accessToken;
        }

        public GetVehicleByIdDTO GetVehicleById(int id)
        {
            var vehicle=_dbContext.VehiclesMD.FirstOrDefault(x=>x.Id == id);
            if(vehicle != null)
            {
                GetVehicleByIdDTO obj = new()
                {
                    Id = vehicle.Id,
                    RegNo = vehicle.RegNo,
                    Model = vehicle.Model,
                    ManufactureDate = vehicle.ManufactureDate
                };
                return obj;
            }
            return null;
            
        }

        public Vehicle UpdateVehicle(int id, VehicleDTO vehicleDTO)
        {
            var vehicle=_dbContext.VehiclesMD.FirstOrDefault(x=>x.Id == id);
            if (vehicle != null)
            {
                vehicle.Model = vehicleDTO.Model;
                vehicle.RegNo = vehicleDTO.RegNo;
                vehicle.ManufactureDate = vehicleDTO.ManufactureDate;
                _dbContext.SaveChanges();
                return vehicle;
            }
            return null;

        }



    }
}
