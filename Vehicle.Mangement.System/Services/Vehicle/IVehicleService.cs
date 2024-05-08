using Vehicle.Management.System.Models.Api;
using Vehicle.Management.System.Models.Data;

namespace Vehicle.Management.System.Services.Vehicle
{
    public interface IVehicleService
    {
        Task<VehicleModel> createVehicle(VehicleDto vehicle);

        Task<List<VehicleModel>> getAllVehicles();

        Task<VehicleModel?> getVehicle(string vehicleId);

        Task<string?> deleteVehicle(string vehicleId);
    }
}
