using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Vehicle.Management.System.Models.Configuration;
using Vehicle.Management.System.Models.Data;

namespace Vehicle.Management.System.Services.Database
{
    public class DatabaseContext(IOptions<VehicleDataBaseSettings> options, IMongoDatabase database) : IDatabaseContext
    {
        private readonly IMongoDatabase _database = database;
        private readonly IOptions<VehicleDataBaseSettings> _options = options;
        private IMongoCollection<VehicleModel>? _vehicles;

        public IMongoCollection<VehicleModel> Vehicles => throw new NotImplementedException();
    }
}
