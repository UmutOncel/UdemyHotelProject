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
    public class EfWorkLocationDAL : GenericRepository<WorkLocation>, IWorkLocationDAL
    {
        public EfWorkLocationDAL(HotelProjectDbContext context) : base(context)
        {
        }
    }
}
