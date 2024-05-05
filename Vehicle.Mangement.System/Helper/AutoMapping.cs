using AutoMapper;
using VehicleManagementSystem.Models.Api;
using VehicleManagementSystem.Models.Data;

namespace VehicleManagementSystem.Helper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<VehicleDto, VehicleModel>().ReverseMap();
        }
    }
}
