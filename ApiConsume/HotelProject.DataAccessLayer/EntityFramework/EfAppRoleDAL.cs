using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repository;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfAppRoleDAL : GenericRepository<AppRole>, IAppRoleDAL
    {
        private readonly RoleManager<AppRole> _roleManager;

        public EfAppRoleDAL(HotelProjectDbContext context, RoleManager<AppRole> roleManager) : base(context)
        {
            _roleManager = roleManager;
        }

        public async Task CreateAppRoleAsync(AppRole appRole)
        {
            await _roleManager.CreateAsync(appRole);    //SaveChanges() yapmaya gerek yok kendisi kaydediyor.
        }

        public async Task DeleteAppRoleAsync(int id)
        {
            var value = await _roleManager.FindByIdAsync(id.ToString());
            await _roleManager.DeleteAsync(value);
        }

        //appRole id'si ile geldiği için (UI kısımında HttpGet ile güncellenecek nesneyi seçiyoruz zaten) burada direkt UpdateAsync() metodunu kullanırız. id ile nesneyi bulmaya çalışmayız. (eğer API kullanmasaydık o zaman önce nesneyi bulup sonra map'leme tarzı işlem yapıp öyle güncelleme yapardık.)
        public async Task UpdateAppRoleAsync(AppRole appRole)
        {
            await _roleManager.UpdateAsync(appRole);
        }
    }
}
