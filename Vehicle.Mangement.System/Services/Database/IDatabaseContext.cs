using MongoDB.Driver;
using VehicleManagementSystem.Models.Data;

namespace VehicleManagementSystem.Services.Database
{
    public interface IDatabaseContext
    {

        IMongoCollection<VehicleModel> Vehicles {  get; }
    }
}
