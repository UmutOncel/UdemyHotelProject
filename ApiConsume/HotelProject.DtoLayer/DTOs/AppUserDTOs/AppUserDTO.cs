using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.DTOs.AppUserDTOs
{
    public class AppUserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public string Department { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public int? WorkLocationId { get; set; }
        public string WorkLocationName { get; set; }
    }
}
