﻿using System.Linq.Expressions;
using AutoFixture;
using AutoMapper;
using MongoDB.Driver;
using Moq;
using Vehicle.Management.System.Models.Api;
using Vehicle.Management.System.Models.Data;
using Vehicle.Management.System.Services.Database;
using Vehicle.Management.System.Services.Vehicle;
using VehicleManagementSystem.Constants;

namespace Vehicle.Management.System.tests.Test.Services
{
    public class VehicleServiceTest
    {
        private readonly Mock<IDatabaseContext> _mockDataBaseContext;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Fixture _fixture = new Fixture();

        public VehicleServiceTest()
        {
            _mockDataBaseContext = new Mock<IDatabaseContext>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task AddVehicle_Should_InsertVehicle()
        {
            var mockVehicleDto = _fixture.Create<VehicleDto>();
            var mockVehicle = _fixture.Create<VehicleModel>();

            _mockMapper
               .Setup(mapper => mapper.Map<VehicleModel>(mockVehicleDto))
               .Returns(mockVehicle);

            var service = new VehicleService(_mockMapper.Object, _mockDataBaseContext.Object);
            VehicleModel result = await service.createVehicle(mockVehicleDto);

            _mockDataBaseContext.Verify(collection =>
                collection.Vehicles.InsertOneAsync(mockVehicle, null, default),
                Times.Once());

            Assert.Equal(mockVehicle, result);
        }

        [Fact]
        public async Task GetVehicle_Should_ReturnVehicle_ByTherId()
        {
            var mockVehicle = _fixture.Create<VehicleModel>();
            var mockVehicleId = _fixture.Create<string>();
            var service = new VehicleService(_mockMapper.Object, _mockDataBaseContext.Object);
            var result = await service.getVehicle(mockVehicleId);

            _mockDataBaseContext.Setup(collection =>
                collection.Vehicles
                .FindAsync(It.IsAny<Expression<Func<VehicleModel, bool>>>(), It
                .IsAny<FindOptions<VehicleModel, VehicleModel>>(), default))
                .ReturnsAsync((IAsyncCursor<VehicleModel>)mockVehicle);

            Assert.Equal(result, mockVehicle);

        }

        [Fact]
        public async Task GetAllVehicle_Should_ReturnAllVehicles()
        {
            var mockVehicles = _fixture.Create<List<VehicleModel>>();
            var service = new VehicleService(_mockMapper.Object, _mockDataBaseContext.Object);
            var result = await service.getAllVehicles();

            _mockDataBaseContext.Setup(collection =>
                collection.Vehicles
                .FindAsync(It.IsAny<Expression<Func<VehicleModel, bool>>>(), It
                .IsAny<FindOptions<VehicleModel, VehicleModel>>(), default))
                .ReturnsAsync((IAsyncCursor<VehicleModel>)mockVehicles);

            Assert.Equal(result, mockVehicles);
        }

        [Fact]
        public async Task DeleteVehicle_Should_ReturnSuccessMessage()
        {
            var message = 1;
            var mockId = _fixture.Create<string>();
            var service = new VehicleService(_mockMapper.Object, _mockDataBaseContext.Object);
            var result = await service.deleteVehicle(mockId);

            _mockDataBaseContext.Setup(collection =>
                collection.Vehicles
                .DeleteOneAsync(It.IsAny<Expression<Func<VehicleModel, bool>>>(), It
                .IsAny<DeleteOptions>(), default))
                .Returns((Task<DeleteResult>)Task.CompletedTask);

            Assert.Equal(result, message);
        }
    }
}
