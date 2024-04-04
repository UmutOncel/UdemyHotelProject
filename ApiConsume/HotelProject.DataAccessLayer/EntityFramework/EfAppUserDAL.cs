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
        public EfAppUserDAL(HotelProjectDbContext context) : base(context)
        {
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
    }
}
