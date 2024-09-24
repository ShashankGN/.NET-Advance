using Vehicle_management.DTO;
using Vehicle_management.Models;

namespace Vehicle_management.Contracts
{
    public interface IVehicleRepo
    {
        public IEnumerable<VehicleDTO> GetAll();

        public string AddVehicle(VehicleDTO vehicleDTO);

        public GetVehicleByIdDTO GetVehicleById(int id);

        public bool DeleteVehicle(int id);

        public Vehicle UpdateVehicle(int id,VehicleDTO vehicleDTO);

        public string GetToken();
    }
}
