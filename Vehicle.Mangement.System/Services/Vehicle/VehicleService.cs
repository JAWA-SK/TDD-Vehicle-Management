using AutoMapper;
using VehicleManagementSystem.Models.Api;
using VehicleManagementSystem.Models.Data;
using VehicleManagementSystem.Services.Database;

namespace VehicleManagementSystem.Services.Vehicle
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
            throw new NotImplementedException();
        }

        public Task<List<VehicleModel>> getAllVehicles()
        {
            throw new NotImplementedException();
        }

        public Task<VehicleModel?> getVehicle(string vehicleId)
        {
            throw new NotImplementedException();
        }


    }
}
