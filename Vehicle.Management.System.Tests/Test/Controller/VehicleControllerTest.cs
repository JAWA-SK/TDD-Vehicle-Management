using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Vehicle.Management.System.Controllers;
using Vehicle.Management.System.Models.Api;
using Vehicle.Management.System.Models.Data;
using Vehicle.Management.System.Services.Vehicle;

namespace Vehicle.Management.System.tests.Test.Controller
{
    public class VehicleControllerTest
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public async Task ShouldReturnOn_GetAllVehicle_AndStatusAs200()
        {
            var mockVehicleService = new Mock<IVehicleService>();
            var mockVehicle = _fixture.Create<List<VehicleModel>>();
            mockVehicleService
                .Setup(service => service.getAllVehicles())
                .ReturnsAsync(mockVehicle);

            var testController = new VehicleController(mockVehicleService.Object);
            var result = await testController.GetAllVehicle();

            mockVehicleService.Verify(service => service.getAllVehicles(), Times.Once());

            result
                .Should().BeOfType<OkObjectResult>().Which.Value.Should()
                .BeOfType<List<VehicleModel>>().And.Subject.As<List<VehicleModel>>()
                .Should().BeEquivalentTo(mockVehicle);

            result
                .Should().BeOfType<OkObjectResult>().Which.StatusCode.Should()
                .Be(StatusCodes.Status200OK);


        }

        [Fact]
        public async Task ShouldReturnOn_NoVehicleFound_AndStatusAs400()
        {
            var mockVehicleService = new Mock<IVehicleService>();

            mockVehicleService
                .Setup(service => service.getAllVehicles())
                .ReturnsAsync(new List<VehicleModel>());

            var testController = new VehicleController(mockVehicleService.Object);
            var result = await testController.GetAllVehicle();

            result
                .Should().BeOfType<NotFoundObjectResult>().Which.StatusCode.Should()
                .Be(StatusCodes.Status400BadRequest);


        }

        [Fact]
        public async Task ShoudlReturnOn_GetVehicleById_AndStatusAs200()
        {
            var mockVehicleService = new Mock<IVehicleService>();
            var testVehicleId = _fixture.Create<string>();
            var mockVehicle = _fixture.Create<VehicleModel>();

            mockVehicleService
                .Setup(service => service.getVehicle(testVehicleId))
                .ReturnsAsync(mockVehicle);

            var testController = new VehicleController(mockVehicleService.Object);
            var result = await testController.GetVehicle(testVehicleId);

            mockVehicleService
                .Verify(service => service.getVehicle(testVehicleId), Times.Once());

            result
                .Should().BeOfType<OkObjectResult>().Which.Value.Should()
                .Be(mockVehicle).And.Subject.As<VehicleModel>().Should()
                .BeEquivalentTo(mockVehicle);

            result
                .Should().BeOfType<OkObjectResult>().Which.StatusCode.Should()
                .Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task ShoudlReturnOn_VehicleNotFoundForId_AndStatusAs400()
        {
            var mockVehicleService = new Mock<IVehicleService>();
            var testVehicleId = _fixture.Create<string>();

            mockVehicleService
                .Setup(service => service.getVehicle(testVehicleId))
                .ReturnsAsync(null as VehicleModel);

            var testController = new VehicleController(mockVehicleService.Object);
            var result = await testController.GetVehicle(testVehicleId);

            result
                .Should().BeOfType<NotFoundResult>().Which.StatusCode.Should()
                .Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task ShouldReturnOn_CreationOfVehicleObject_AndStatusAs201()
        {
            var mockVehicle = _fixture.Create<VehicleModel>();
            var mockVehicleDto = _fixture.Create<VehicleDto>();
            var mockVehicleService = new Mock<IVehicleService>();

            mockVehicleService
                .Setup(service => service.createVehicle(mockVehicleDto)).
                ReturnsAsync(mockVehicle);

            var testController = new VehicleController(mockVehicleService.Object);
            var result = await testController.CreateVehicle(mockVehicleDto);

            mockVehicleService
                .Verify(service => service.createVehicle(mockVehicleDto), Times.Once());

            result
                .Should().BeOfType<OkObjectResult>().Which.Value.Should()
                .Be(mockVehicle).And.Subject.As<VehicleModel>().Should()
                .BeEquivalentTo(mockVehicle);


            result
                .Should().BeOfType<OkObjectResult>().Which.StatusCode.Should()
                .Be(StatusCodes.Status201Created);
        }

        [Fact]
        public async Task ShouldReturnOn_InvalidVehicleObject_AndStatusAs406()
        {
            var mockVehicle = new VehicleModel();
            var mockVehicleDto = new VehicleDto();
            var mockVehicleService = new Mock<IVehicleService>();

            mockVehicleService
                .Setup(service => service.createVehicle(mockVehicleDto))
                .ReturnsAsync(mockVehicle);

            var testController = new VehicleController(mockVehicleService.Object);
            var result = await testController.CreateVehicle(mockVehicleDto);

            mockVehicleService
                .Verify(service => service.createVehicle(mockVehicleDto), Times.Once());

            result
                .Should().BeOfType<BadRequestResult>().Which.StatusCode.Should()
                .Be(StatusCodes.Status406NotAcceptable);
        }

        [Fact]
        public async Task ShouldReturnOn_DeleteVehicle_AndStatusAs200()
        {
            var mockVehicleId = _fixture.Create<string>();
            var mockVehicleService = new Mock<IVehicleService>();

            mockVehicleService
                .Setup(service => service.deleteVehicle(mockVehicleId))
                .ReturnsAsync("Deleted");

            var testController = new VehicleController(mockVehicleService.Object);
            var result = await testController.DeleteVehicle(mockVehicleId);

            mockVehicleService
                .Verify(service => service.deleteVehicle(mockVehicleId), Times.Once());

            result
                .Should().BeOfType<OkObjectResult>().Which.StatusCode.Should()
                .Be(StatusCodes.Status200OK);

        }

        [Fact]
        public async Task ShouldReturnOn_InvalidIdNotFoundForDelete_AndStatusAs406()
        {
            var mockVehicleId = "";
            var mockVehicleService = new Mock<IVehicleService>();

            mockVehicleService
                .Setup(service => service.deleteVehicle(mockVehicleId))
                .ReturnsAsync("Invalid Vehicle Id");

            var testController = new VehicleController(mockVehicleService.Object);
            var result = await testController.DeleteVehicle(mockVehicleId);

            mockVehicleService
                .Verify(service => service.deleteVehicle(mockVehicleId), Times.Once());

            result
                .Should().BeOfType<BadRequestResult>().Which.StatusCode.Should()
                .Be(StatusCodes.Status406NotAcceptable);

        }
    }
}