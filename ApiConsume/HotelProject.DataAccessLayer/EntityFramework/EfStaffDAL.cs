using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repository;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfStaffDAL: GenericRepository<Staff>, IStaffDAL
    {
        public EfStaffDAL(HotelProjectDbContext context) : base(context)
        {
                
        }

        public List<Staff> GetLast4Staff()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            var values = context.Staffs.OrderByDescending(x => x.StaffID).Take(4).ToList();
            return values;
        }

        public int GetStaffCount()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            return context.Staffs.Count();
        }
    }
}
