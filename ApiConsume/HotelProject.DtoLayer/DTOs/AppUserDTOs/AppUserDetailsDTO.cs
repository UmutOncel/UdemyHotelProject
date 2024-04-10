using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.DTOs.AppUserDTOs
{
    public class AppUserDetailsDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public List<string> WorkLocationName { get; set; }
        public List<string> AppRoles { get; set; }
    }
}
