using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repository;
using HotelProject.DtoLayer.DTOs.AppUserDTOs;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfAppUserDAL : GenericRepository<AppUser>, IAppUserDAL
    {
        private readonly UserManager<AppUser> _userManager;

        public EfAppUserDAL(HotelProjectDbContext context, UserManager<AppUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public int GetAppUserCount()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            return context.Users.Count();
        }

        //AppUser ve WorkLocation arasında bire çok ilişki vardı. AppUser içinden WorkLocation'ın Name'ine ulaşmak için AppUser içindeki WorkLocation prop'unun dolu gelmesi gerekiyor. Bunun için "Include" metodunu kullandık. Yalnız tek başına onu kullanmak yeterli olmuyor. WorkLocationName'e yine ulaşamıyoruz. Burada iç içe geçmiş (Nested) bir yapı olduğu için bir DTO yarattık. Onun prop'ları içine "Select" yapısı ile verileri yolladık. 
        public List<AppUserDTO> GetUserListWithWorkLocation()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();

            //Users içine WorkLocation'ı dahil et.
            var values = context.Users.Include(x => x.WorkLocation)
                                      .Select(y => new AppUserDTO {
                                          Id = y.Id,
                                          Name = y.Name,
                                          Surname = y.Surname,
                                          City = y.City,
                                          ImageUrl = y.ImageUrl,
                                          Country = y.Country,
                                          Gender = y.Gender,
                                          WorkLocationId = y.WorkLocationId,
                                          WorkLocationName = y.WorkLocation.Name
                                      }).ToList();
            return values;
        }

        public async Task<AppUserDetailsDTO> GetUserWithRoleAndWorkLocation(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var userRoles = await _userManager.GetRolesAsync(user);
            
            HotelProjectDbContext context = new HotelProjectDbContext();
            //tek veri olmasına rağmen liste şeklinde döndürüyor. o yüzden ToList() yaptık.
            var workLocationName = context.WorkLocations.Where(x => x.WorkLocationID == user.WorkLocationId)
                                                        .Select(x => x.Name)
                                                        .ToList();
            
            AppUserDetailsDTO appUserDetailsDTO = new AppUserDetailsDTO
            {
                Name = user.Name,
                Surname = user.Surname,
                Username = user.UserName,
                City = user.City,
                Country = user.Country,
                Gender = user.Gender,
                Email = user.Email,
                ImageUrl = user.ImageUrl,
                WorkLocationName = workLocationName,
                AppRoles = userRoles.ToList()
            };
            return appUserDetailsDTO;
        }
    }
}
