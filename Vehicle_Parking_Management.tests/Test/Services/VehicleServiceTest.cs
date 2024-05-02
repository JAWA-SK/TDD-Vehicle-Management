using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using Vehicle_Parking_Management.Models;
using Vehicle_Parking_Management.Models.Api;
using Vehicle_Parking_Management.Services;

namespace Vehicle_Parking_Management.tests.Test.Services
{
    public  class VehicleServiceTest
    {
        private  readonly Mock<IMongoCollection<Vehicle>> _mockCollection; 
        private  readonly Mock<IMongoClient> _mockClient;
        private  readonly Mock<IOptions<VehicleDataBaseSettings>> _mockDbSettings;
        private  readonly Mock<IMapper> _mockMapper;
        private readonly Fixture _fixture=new Fixture();
    public VehicleServiceTest()
    {
        _mockCollection = new Mock<IMongoCollection<Vehicle>>();
        _mockClient = new Mock<IMongoClient>();
        _mockDbSettings = new Mock<IOptions<VehicleDataBaseSettings>>();
        _mockMapper = new Mock<IMapper>();
    }


        [Fact]
        public async Task AddVehicle_Should_InsertVehicle()
        {
            var mockVehicleDto= _fixture.Create<VehicleDto>();
            var mockVehicle = _fixture.Create<Vehicle>();

            _mockMapper.Setup(mapper=>mapper.Map<Vehicle>(mockVehicleDto)).Returns(mockVehicle);

            var service=new VehicleService(_mockDbSettings.Object,_mockClient.Object, _mockMapper.Object);

            var result=await service.createVehicle(mockVehicleDto);

            _mockCollection.Verify(vehicle=>vehicle.InsertOneAsync(mockVehicle,null,default),Times.Once());
        }
    }

}
