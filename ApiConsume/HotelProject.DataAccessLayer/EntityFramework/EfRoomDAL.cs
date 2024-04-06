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

        public List<Room> Get3Rooms()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            var values = context.Rooms.OrderBy(x => x.RoomID).Take(3).ToList();
            return values;
        }

        public int GetRoomCount()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            return context.Rooms.Count();
        }
    }
}
