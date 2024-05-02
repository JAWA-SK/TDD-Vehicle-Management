using AutoMapper;
using Vehicle_Parking_Management.Models;
using Vehicle_Parking_Management.Models.Api;

namespace Vehicle_Parking_Management.Mapping
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<VehicleDto,Vehicle>().ReverseMap();
        }
    }
}
