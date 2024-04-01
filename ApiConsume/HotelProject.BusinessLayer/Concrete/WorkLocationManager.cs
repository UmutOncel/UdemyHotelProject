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
    public class WorkLocationManager : IWorkLocationService
    {
        private readonly IWorkLocationDAL _workLocationDAL;

        public WorkLocationManager(IWorkLocationDAL workLocationDAL)
        {
            _workLocationDAL = workLocationDAL;
        }

        public void TDelete(WorkLocation t)
        {
            _workLocationDAL.Delete(t);
        }

        public WorkLocation TGetByID(int id)
        {
            return _workLocationDAL.GetByID(id);
        }

        public List<WorkLocation> TGetList()
        {
            return _workLocationDAL.GetList();
        }

        public void TInsert(WorkLocation t)
        {
            _workLocationDAL.Insert(t);
        }

        public void TUpdate(WorkLocation t)
        {
            _workLocationDAL.Update(t);
        }
    }
}
