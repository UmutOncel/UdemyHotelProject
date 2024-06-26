﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class RoomManager : IRoomService
    {
        private readonly IRoomDAL _roomDAL;

        public RoomManager(IRoomDAL roomDAL)
        {
            _roomDAL = roomDAL;
        }

        public void TDelete(Room t)
        {
            _roomDAL.Delete(t);
        }

        public List<Room> TGet3Rooms()
        {
            return _roomDAL.Get3Rooms();
        }

        public Room TGetByID(int id)
        {
            return _roomDAL.GetByID(id);
        }

        public List<Room> TGetList()
        {
            return _roomDAL.GetList();
        }

        public int TGetRoomCount()
        {
            return _roomDAL.GetRoomCount();
        }

        public void TInsert(Room t)
        {
            _roomDAL.Insert(t);
        }

        public void TUpdate(Room t)
        {
            _roomDAL.Update(t);
        }
    }
}
