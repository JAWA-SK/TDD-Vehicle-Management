using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vehicle_Parking_Management.Services;

namespace Vehicle_Parking_Management
{
    [Route("api")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("getAllVehicle")]
        public async Task<IActionResult> GetAllVehicle()
        {
           
            return Ok("success");
        }

        [HttpGet("getVehicle")]

        public async Task<IActionResult>GetVehicle(string vehicleId)
        {
            return Ok("success");
        }

    }
}
