using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IBookingDAL: IGenericDAL<Booking>
    {
        void ChangeBookingStatusToApproved(int id);
        void ChangeBookingStatusToPended(int id);
        void ChangeBookingStatusToRejected(int id);
    }
}
