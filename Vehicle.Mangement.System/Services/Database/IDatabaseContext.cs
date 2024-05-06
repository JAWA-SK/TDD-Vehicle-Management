using MongoDB.Driver;
using Vehicle.Management.System.Models.Data;

namespace Vehicle.Management.System.Services.Database
{
    public interface IDatabaseContext
    {
        IMongoCollection<VehicleModel> Vehicles { get; }
    }
}
