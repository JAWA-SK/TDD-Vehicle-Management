using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Vehicle_Parking_Management.Models;
using Vehicle_Parking_Management.Services;
using Vehicle_Parking_Management.tests.Test.fixtures;

namespace Vehicle_Parking_Management.tests.Test.Controller
{
    public class TestVehicleController
    {
        [Fact]
        public async Task ShouldReturnOn_GetAllVehicle_AndStatusAs200()
        {
            var mockVehicleService = new Mock<IVehicleService>();
            mockVehicleService.Setup(service => service.getAllVehicles()).
                ReturnsAsync(VehicleFixture.GetAllTestVehicles());

            var testController = new VehicleController(mockVehicleService.Object);
            var result = await testController.GetAllVehicle();

            mockVehicleService.Verify(service => service.getAllVehicles(), Times.Once());
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<Vehicle>>();
            objectResult.StatusCode.Should().Be(200);


        }
        [Fact]
        public async Task ShouldReturnOn_NoVehicleFound_AndStatusAs400()
        {
            var mockVehicleService = new Mock<IVehicleService>();
            mockVehicleService.Setup(service => service.getAllVehicles()).
              ReturnsAsync(new List<Vehicle>());

            var testController = new VehicleController(mockVehicleService.Object);
            var result = await testController.GetAllVehicle();

            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundObjectResult)result;
            objectResult.StatusCode.Should().Be(400);


        }

        [Fact]
        public async Task ShoudlReturnOn_GetVehicleById_AndStatusAs200()
        {
            var mockVehicleService = new Mock<IVehicleService>();
            var testVehicleId = "1";
            var testVehicle = VehicleFixture.GetTestVehicle(testVehicleId);
            mockVehicleService.Setup(service => service.getVehicle(testVehicleId))
                .ReturnsAsync(testVehicle);

            var testController = new VehicleController(mockVehicleService.Object);
            var result = await testController.GetVehicle(testVehicleId);

            mockVehicleService.Verify(service => service.getVehicle(testVehicleId), Times.Once());
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeEquivalentTo(testVehicle);
            objectResult.StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task ShoudlReturnOn_VehicleNotFoundForId_AndStatusAs400()
        {
            var mockVehicleService = new Mock<IVehicleService>();
            var testVehicleId = "1";
            var testVehicle = VehicleFixture.GetTestVehicle(testVehicleId);
            mockVehicleService.Setup(service => service.getVehicle(testVehicleId))
                .ReturnsAsync(null as Vehicle);

            var testController = new VehicleController(mockVehicleService.Object);
            var result = await testController.GetVehicle(testVehicleId);

            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(400);
        }
    }
}