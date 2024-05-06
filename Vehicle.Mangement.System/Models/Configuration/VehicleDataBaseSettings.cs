namespace Vehicle.Management.System.Models.Configuration
{
    public record VehicleDataBaseSettings
    {
        public string ConnectionUrl { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }
    }
}
