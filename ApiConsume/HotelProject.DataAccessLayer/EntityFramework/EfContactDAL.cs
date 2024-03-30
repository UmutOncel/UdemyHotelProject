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
    public class EfContactDAL : GenericRepository<Contact>, IContactDAL
    {
        public EfContactDAL(HotelProjectDbContext context) : base(context)
        {
        }

        public int GetContactCount()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            return context.Contacts.Count();
        }
    }
}
