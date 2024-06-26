﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DtoLayer.DTOs.AppUserDTOs;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDAL _appUserDAL;

        public AppUserManager(IAppUserDAL appUserDAL)
        {
            _appUserDAL = appUserDAL;
        }

        public void TDelete(AppUser t)
        {
            _appUserDAL.Delete(t);
        }

        public int TGetAppUserCount()
        {
            return _appUserDAL.GetAppUserCount();
        }

        public AppUser TGetByID(int id)
        {
            return _appUserDAL.GetByID(id); 
        }

        public List<AppUser> TGetList()
        {
            return _appUserDAL.GetList();
        }

        public List<AppUserDTO> TGetUserListWithWorkLocation()
        {
            return _appUserDAL.GetUserListWithWorkLocation();
        }

        public Task<AppUserDetailsDTO> TGetUserWithRoleAndWorkLocation(int id)
        {
            return _appUserDAL.GetUserWithRoleAndWorkLocation(id);
        }

        public void TInsert(AppUser t)
        {
            _appUserDAL.Insert(t);
        }

        public void TUpdate(AppUser t)
        {
            _appUserDAL.Update(t);
        }
    }
}
