using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Parking_Management.Models;

namespace Vehicle_Parking_Management.tests.Test.fixtures
{
    public static class VehicleFixture
    {
        public static List<Vehicle> GetAllTestVehicles() => new()
        {
            new Vehicle
            {
                VehicleType="4 Wheeler",
                Floor="2 Floor",
                RegisteredState="TN",
                ParkedTime=DateTime.Now
            }
        };
        public static Vehicle GetTestVehicle(string vehicleId)
        {
            return new Vehicle
            {
                VehicleId = vehicleId,
                VehicleType = "4 Wheeler",
                Floor = "2 Floor",
                RegisteredState = "TN",
                ParkedTime = DateTime.Now
            };
        }
    }
}