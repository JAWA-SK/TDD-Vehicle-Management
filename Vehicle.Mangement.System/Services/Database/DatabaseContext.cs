using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Vehicle.Management.System.Models.Configuration;
using Vehicle.Management.System.Models.Data;

namespace Vehicle.Management.System.Services.Database
{
    public class DatabaseContext : IDatabaseContext
    {

        private readonly IMongoCollection<VehicleModel> _vehicleCollection;
        public DatabaseContext(IOptions<VehicleDataBaseSettings> dbSettings, IMongoClient client)
        {
            var database = client.GetDatabase(dbSettings.Value.DatabaseName);
            _vehicleCollection = database.GetCollection<VehicleModel>(dbSettings.Value.CollectionName);
        }

        public IMongoCollection<VehicleModel> Vehicles =>
             _vehicleCollection;
    }
}
