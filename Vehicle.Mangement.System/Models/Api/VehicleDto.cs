namespace Vehicle.Management.System.Models.Api
{
    public record VehicleDto
    {
        public string VehicleType { get; set; }

        public string Floor { get; set; }

        public string RegisteredState { get; set; }

        public DateTime ParkedTime { get; set; }
    }
}
