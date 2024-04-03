using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AppRoleManager : IAppRoleService
    {
        private readonly IAppRoleDAL _appRoleDAL;

        public AppRoleManager(IAppRoleDAL appRoleDAL)
        {
            _appRoleDAL = appRoleDAL;
        }

        public async Task TCreateAppRoleAsync(AppRole appRole)
        {
            await _appRoleDAL.CreateAppRoleAsync(appRole);
        }

        public void TDelete(AppRole t)
        {
            _appRoleDAL.Delete(t);
        }

        public async Task TDeleteAppRoleAsync(int id)
        {
            await _appRoleDAL.DeleteAppRoleAsync(id);
        }

        public AppRole TGetByID(int id)
        {
            return _appRoleDAL.GetByID(id);
        }

        public List<AppRole> TGetList()
        {
            return _appRoleDAL.GetList();
        }

        public void TInsert(AppRole t)
        {
            _appRoleDAL.Insert(t);
        }

        public void TUpdate(AppRole t)
        {
            _appRoleDAL.Update(t);
        }

        public async Task TUpdateAppRoleAsync(AppRole appRole)
        {
            await _appRoleDAL.UpdateAppRoleAsync(appRole);
        }
    }
}
