using Vehicle_Parking_Management.Models.Api;
using VehicleManagementSystem.Models.Data;

namespace VehicleManagementSystem.Services.Vehicle
{
    public interface IVehicleService
    {

        Task<VehicleModel> createVehicle(VehicleDto vehicle);

        Task<List<VehicleModel>> getAllVehicles();

        Task<VehicleModel?> getVehicle(string vehicleId);


    }
}
