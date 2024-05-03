using Vehicle_Parking_Management.Models.Api;
using VehicleManagementSystem.Models.Data;

namespace Vehicle_Parking_Management.Services
{
    public interface IVehicleService
    {

        Task<VehicleModel> createVehicle(VehicleDto vehicle);

        Task<List<VehicleModel>> getAllVehicles();

        Task<VehicleModel?> getVehicle(string vehicleId);


    }
}
