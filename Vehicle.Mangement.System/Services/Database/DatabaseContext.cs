using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VehicleManagementSystem.Models.Configuration;
using VehicleManagementSystem.Models.Data;

namespace VehicleManagementSystem.Services.Database
{
    public class DatabaseContext(IOptions<VehicleDataBaseSettings> options, IMongoDatabase database) : IDatabaseContext
    {
        private readonly IMongoDatabase _database = database;
        private readonly IOptions<VehicleDataBaseSettings> _options = options;
        private IMongoCollection<VehicleModel>? _vehicles;

        public IMongoCollection<VehicleModel> Vehicles =>
            _vehicles ??= _database.GetCollection<VehicleModel>(_options.Value.CollectionName);


    }
}
