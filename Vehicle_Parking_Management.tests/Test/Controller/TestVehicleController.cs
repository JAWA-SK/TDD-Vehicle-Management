using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Vehicle_Parking_Management.Models;
using Vehicle_Parking_Management.Services;

namespace Vehicle_Parking_Management.tests.Test.Controller
{
    public class TestVehicleController
    {
        private readonly Fixture _fixture = new Fixture();
        [Fact]
        public async Task ShouldReturnOn_GetAllVehicle_AndStatusAs200()
        {
            var mockVehicleService = new Mock<IVehicleService>();
            var mockVehicle=_fixture.Create<List<Vehicle>>();
            mockVehicleService.Setup(service => service.getAllVehicles()).
                ReturnsAsync(mockVehicle);

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
            var mockVehicle = _fixture.Create<Vehicle>();
            mockVehicleService.Setup(service => service.getVehicle(testVehicleId))
                .ReturnsAsync(mockVehicle);

            var testController = new VehicleController(mockVehicleService.Object);
            var result = await testController.GetVehicle(testVehicleId);

            mockVehicleService.Verify(service => service.getVehicle(testVehicleId), Times.Once());
            var objectResult = (OkObjectResult)result;
            result.Should().BeOfType<OkObjectResult>();
            objectResult.Value.Should().BeEquivalentTo(mockVehicle);
            objectResult.StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task ShoudlReturnOn_VehicleNotFoundForId_AndStatusAs400()
        {
            var mockVehicleService = new Mock<IVehicleService>();
            var testVehicleId = "1";
            mockVehicleService.Setup(service => service.getVehicle(testVehicleId))
                .ReturnsAsync(null as Vehicle);

            var testController = new VehicleController(mockVehicleService.Object);
            var result = await testController.GetVehicle(testVehicleId);

            var objectResult = (NotFoundResult)result;
            result.Should().BeOfType<NotFoundResult>();
            objectResult.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task ShouldReturnOn_CreationOfVehicleObject_AndStatusAs201()
        {
            var mockVehicle = _fixture.Create<Vehicle>();
            var mockVehicleService=new Mock<IVehicleService>();
            mockVehicleService.Setup(service=>service.createVehicle(mockVehicle)).
                ReturnsAsync(mockVehicle);

            var testController=new VehicleController(mockVehicleService.Object);
            var result =await testController.CreateVehicle(mockVehicle);

            var objectResult=(OkObjectResult)result;

            mockVehicleService.Verify(service=> service.createVehicle(mockVehicle),Times.Once());
            objectResult.Should().BeOfType<OkObjectResult>();
            objectResult.Value.Should().BeEquivalentTo(mockVehicle);
            objectResult.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task ShouldReturnOn_InvalidVehicleObject_AndStatusAs406()
        {
            var mockVehicle =new Vehicle();
            var mockVehicleService = new Mock<IVehicleService>();
            mockVehicleService.Setup(service => service.createVehicle(mockVehicle)).
                ReturnsAsync(mockVehicle);

            var testController = new VehicleController(mockVehicleService.Object);
            var result = await testController.CreateVehicle(mockVehicle);

            var objectResult = (BadRequestResult)result;

            mockVehicleService.Verify(service => service.createVehicle(mockVehicle), Times.Once());
            objectResult.Should().BeOfType<BadRequestResult>();
            objectResult.StatusCode.Should().Be(406);
        }
    }
}