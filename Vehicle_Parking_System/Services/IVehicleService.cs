using Vehicle_Parking_Management.Models;
using Vehicle_Parking_Management.Models.Api;

namespace Vehicle_Parking_Management.Services
{
    public interface IVehicleService
    {

        Task<Vehicle> createVehicle(VehicleDto vehicle);

        Task<List<Vehicle>> getAllVehicles();

        Task<Vehicle?> getVehicle(string vehicleId);


    }
}
