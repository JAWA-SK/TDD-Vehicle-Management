using AutoMapper;
using MongoDB.Driver;
using Vehicle.Management.System.Models.Api;
using Vehicle.Management.System.Models.Data;
using Vehicle.Management.System.Services.Database;

namespace Vehicle.Management.System.Services.Vehicle
{
    public class VehicleService : IVehicleService
    {
        private IMapper _mapper;
        private IDatabaseContext _databaseContext;

        public VehicleService(IMapper mapper, IDatabaseContext databaseContext)
        {
            _mapper = mapper;
            _databaseContext = databaseContext;
        }

        public async Task<VehicleModel> createVehicle(VehicleDto vehicle)
        {
            var vehicleData = _mapper.Map<VehicleModel>(vehicle);

            await _databaseContext
                .Vehicles
                .InsertOneAsync(vehicleData);

            return vehicleData;

        }

        public async Task<long> deleteVehicle(string vehicleId)
        {
            var vehicle = await _databaseContext.Vehicles.DeleteOneAsync(vehicle =>
            vehicle.VehicleId == vehicleId);
            return vehicle.DeletedCount;
        }

        public async Task<List<VehicleModel>> getAllVehicles()
        {
            return await _databaseContext
                .Vehicles
                .Find(vehicle => true)
                .ToListAsync();
        }

        public async Task<VehicleModel?> getVehicle(string vehicleId)
        {
            return await _databaseContext
                .Vehicles
                .Find(vehicle => vehicle.VehicleId == vehicleId)
                .FirstOrDefaultAsync();


        }


    }
}
