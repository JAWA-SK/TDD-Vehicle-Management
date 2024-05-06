using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Vehicle.Management.System.Models.Data
{
    public record VehicleModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string VehicleId { get; set; }

        public string VehicleType { get; set; }

        public string Floor { get; set; }

        public string RegisteredState { get; set; }

        public DateTime ParkedTime { get; set; }
    }
}
