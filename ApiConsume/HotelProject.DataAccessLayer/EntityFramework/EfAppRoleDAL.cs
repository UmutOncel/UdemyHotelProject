using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repository;
using HotelProject.DtoLayer.DTOs.AppRoleDTOs;
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
        private readonly UserManager<AppUser> _userManager;

        public EfAppRoleDAL(HotelProjectDbContext context, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager) : base(context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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

        public async Task<List<RoleAssignDTO>> GetAssignRoleAsync(int id)
        {
            //id'den kullanıcıyı buluyoruz.
            var user = await _userManager.FindByIdAsync(id.ToString());

            //kullanıcının tüm rollerini listeliyoruz.
            var userRoles = await _userManager.GetRolesAsync(user);

            //role tablosundaki tüm rolleri listeliyoruz.
            var roles = _roleManager.Roles.ToList();
            
            //boş bir tane RoleAssignDTO (oluşturmak istediğimiz yapıya uygun DTO yarattık.) tipinde liste tanımlanır. 
            List<RoleAssignDTO> roleList = new List<RoleAssignDTO>();
            
            //foreach döngüsü ile "roles" listesindeki elemanlar, bizim istediğimiz yapıya uygun şekildeki prop'larıyla, tek tek "roleList" listesine eklenir.
            foreach (var item in roles)
            {
                RoleAssignDTO model = new RoleAssignDTO();
                model.RoleId = item.Id;
                model.RoleName = item.Name;
                model.IsRoleExist = userRoles.Contains(item.Name);  //eğer item'daki rol kullanıcının rol listesi içinde varsa "IsRoleExist" prop'u true döner. (UI tarafında checkbox'ta kullanacağız.)
                model.UserId = id;      //Post metodunda lazım olduğundan id'yi de tutuyoruz.
                roleList.Add(model);
            }
            return roleList;
        }

        public async Task PostAssignRoleAsync(List<RoleAssignDTO> roleList)
        {
            int userId = roleList.Select(x => x.UserId).First();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            foreach (var item in roleList)
            {
                if (item.IsRoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else 
                { 
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
        }
    }
}
