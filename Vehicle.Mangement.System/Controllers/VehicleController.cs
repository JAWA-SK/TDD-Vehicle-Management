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
            var vehicles = await _vehicleService.getAllVehicles();
            return Ok(vehicles);
        }

        [HttpGet("getVehicle")]
        public async Task<IActionResult> GetVehicle(string vehicleId)
        {
            var vehicle = await _vehicleService.getVehicle(vehicleId);
            return vehicle is null ? new NotFoundObjectResult(ApiMessages.InvalidId)
            { StatusCode = StatusCodes.Status404NotFound } : Ok(vehicle);

        }

        [HttpPost("createVehicle")]
        public async Task<ActionResult> CreateVehicle(VehicleDto vehicle)
        {
            var createVehicle = await _vehicleService.createVehicle(vehicle);

            return createVehicle is null ? new BadRequestObjectResult(ApiMessages.Invalid_Data)
            { StatusCode = StatusCodes.Status406NotAcceptable } : CreatedAtAction(nameof(GetVehicle),
            new { id = createVehicle.VehicleId }, createVehicle);
        }

        [HttpDelete("deleteVehicle")]
        public async Task<ActionResult> DeleteVehicle(string vehicleId)
        {
            var count = await _vehicleService.deleteVehicle(vehicleId);

            return count <= 0 ? new NotFoundObjectResult(ApiMessages.InvalidId)
            { StatusCode = StatusCodes.Status404NotFound } : Ok(ApiMessages.Delete);

        }
    }
}
