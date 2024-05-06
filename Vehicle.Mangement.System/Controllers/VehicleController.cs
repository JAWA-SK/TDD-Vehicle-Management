using Microsoft.AspNetCore.Mvc;
using Vehicle.Management.System.Models.Api;
using Vehicle.Management.System.Services.Vehicle;

namespace Vehicle.Management.System.Controllers
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
        public async Task<IActionResult> GetVehicle(string vehicleId)
        {
            return Ok("success");
        }

        [HttpPost("createVehicle")]
        public async Task<ActionResult> CreateVehicle(VehicleDto vehicle)
        {
            return Ok("Created");
        }

    }
}
