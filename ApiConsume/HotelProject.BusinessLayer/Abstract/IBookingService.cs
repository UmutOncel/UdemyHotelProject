using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IBookingService: IGenericService<Booking>
    {
        void TChangeBookingStatusToApproved(int id);
        void TChangeBookingStatusToPended(int id);
        void TChangeBookingStatusToRejected(int id);
    }
}
