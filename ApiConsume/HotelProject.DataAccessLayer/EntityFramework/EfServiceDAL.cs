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
    public class EfServiceDAL: GenericRepository<Service>, IServiceDAL
    {
        public EfServiceDAL(HotelProjectDbContext context) : base(context)
        {
            
        }

        public List<Service> Get6Services()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            var values = context.Services.OrderBy(x => x.ServiceID).Take(6).ToList();
            return values;
        }
    }
}
