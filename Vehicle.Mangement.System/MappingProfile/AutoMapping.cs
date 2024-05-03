using AutoMapper;
using Vehicle_Parking_Management.Models.Api;
using VehicleManagementSystem.Models.Data;

namespace Vehicle_Parking_Management.Mapping
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<VehicleDto,VehicleModel>().ReverseMap();
        }
    }
}
