using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repository;
using HotelProject.EntityLayer.Concrete;
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

        public List<AppUser> GetUserListWithWorkLocation()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();

            //Users içine WorkLocation'ı dahil et.
            return context.Users.Include(x => x.WorkLocation).ToList();
        }
    }
}
