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
    public class EfBookingDAL: GenericRepository<Booking>, IBookingDAL
    {
        public EfBookingDAL(HotelProjectDbContext context) : base(context)
        {
            
        }

        public void ChangeBookingStatusToApproved(int id)
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            var value = context.Bookings.Find(id);
            value.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void ChangeBookingStatusToPended(int id)
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            var value = context.Bookings.Find(id);
            value.Status = "Onay Bekliyor";
            context.SaveChanges();
        }

        public void ChangeBookingStatusToRejected(int id)
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            var value = context.Bookings.Find(id);
            value.Status = "İptal Edildi";
            context.SaveChanges();
        }

        public int GetBookingCount()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            return context.Bookings.Count();
        }

        public List<Booking> GetLast6Booking()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            var values = context.Bookings.OrderByDescending(x => x.BookingID).Take(6).ToList();
            return values;
        }
    }
}
