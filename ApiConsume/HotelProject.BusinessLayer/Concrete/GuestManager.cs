using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class GuestManager : IGuestService
    {
        private readonly IGuestDAL _guestDAL;

        public GuestManager(IGuestDAL guestDAL)
        {
            _guestDAL = guestDAL;
        }

        public void TDelete(Guest t)
        {
            _guestDAL.Delete(t);
        }

        public Guest TGetByID(int id)
        {
            return _guestDAL.GetByID(id);
        }

        public List<Guest> TGetList()
        {
            return _guestDAL.GetList();
        }

        public void TInsert(Guest t)
        {
            _guestDAL.Insert(t);
        }

        public void TUpdate(Guest t)
        {
            _guestDAL.Update(t);
        }
    }
}
