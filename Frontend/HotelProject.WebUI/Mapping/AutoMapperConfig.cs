using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.DTOs.LoginDTOs;
using HotelProject.WebUI.DTOs.RegisterDTOs;
using Microsoft.Build.Framework.Profiler;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AppUser, AddNewUserDTO>().ReverseMap();
            CreateMap<AppUser, LoginUserDTO>().ReverseMap();
        }
    }
}
