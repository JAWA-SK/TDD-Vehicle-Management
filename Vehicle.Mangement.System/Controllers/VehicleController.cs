using Microsoft.AspNetCore.Mvc;
using Vehicle.Management.System.Models.Api;
using Vehicle.Management.System.Services.Vehicle;
using VehicleManagementSystem.Constants;

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

            return Ok(ApiMessages.Success);
        }

        [HttpGet("getVehicle")]
        public async Task<IActionResult> GetVehicle(string vehicleId)
        {
            return Ok(ApiMessages.Success);
        }

        [HttpPost("createVehicle")]
        public async Task<ActionResult> CreateVehicle(VehicleDto vehicle)
        {
            return Ok(ApiMessages.Created);
        }

        [HttpDelete("deleteVehicle")]
        public async Task<ActionResult> DeleteVehicle(string vehicleId)
        {
            return Ok("");
        }
    }
}
