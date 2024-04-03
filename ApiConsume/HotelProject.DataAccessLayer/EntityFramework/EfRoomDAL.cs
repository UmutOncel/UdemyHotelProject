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
    public class EfRoomDAL: GenericRepository<Room>, IRoomDAL
    {
        public EfRoomDAL(HotelProjectDbContext context) : base(context)
        { 

        }

        public int GetRoomCount()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            return context.Rooms.Count();
        }
    }
}
