using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Vehicle_Parking_Management.Models;
using Vehicle_Parking_Management.Models.Api;

namespace Vehicle_Parking_Management.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IMongoCollection<Vehicle> _vehicleCollection;
        private IMapper _mapper;
        public VehicleService(IOptions<VehicleDataBaseSettings> dbSettings, IMongoClient client, IMapper mapper)
        {
            var database = client.GetDatabase(dbSettings.Value.DatabaseName);
            _vehicleCollection = database.GetCollection<Vehicle>(dbSettings.Value.CollectionName);
            _mapper = mapper;
        }
        public async Task<Vehicle> createVehicle(VehicleDto vehicle)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vehicle>> getAllVehicles()
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle?> getVehicle(string vehicleId)
        {
            throw new NotImplementedException();
        }

 
    }
}
