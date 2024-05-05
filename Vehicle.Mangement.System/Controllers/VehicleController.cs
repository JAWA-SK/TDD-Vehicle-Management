using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Models.Api;
using VehicleManagementSystem.Services.Vehicle;

namespace VehicleManagementSystem.Controllers
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
