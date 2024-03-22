using AutoMapper;
using HotelProject.DtoLayer.DTOs.RoomDTOs;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AddRoomDTO, Room>().ReverseMap();
            CreateMap<UpdateRoomDTO, Room>().ReverseMap();
        }
    }
}
