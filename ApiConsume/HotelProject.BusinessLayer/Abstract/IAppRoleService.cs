﻿using HotelProject.DtoLayer.DTOs.AppRoleDTOs;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IAppRoleService: IGenericService<AppRole>
    {
        Task TCreateAppRoleAsync(AppRole appRole);
        Task TDeleteAppRoleAsync(int id);
        Task TUpdateAppRoleAsync(AppRole appRole);
        Task<List<RoleAssignDTO>> TGetAssignRoleAsync(int id);
        Task TPostAssignRoleAsync(List<RoleAssignDTO> roleList);
    }
}
