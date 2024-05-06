using AutoMapper;
using Vehicle.Management.System.Models.Api;
using Vehicle.Management.System.Models.Data;

namespace Vehicle.Management.System.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<VehicleDto, VehicleModel>().ReverseMap();
        }
    }
}
