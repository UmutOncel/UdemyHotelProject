using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.DTOs.AppRoleDTOs
{
    public class RoleAssignDTO
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsRoleExist { get; set; }
        public int UserId { get; set; }
    }
}
