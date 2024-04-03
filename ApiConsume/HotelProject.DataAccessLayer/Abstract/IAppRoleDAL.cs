using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IAppRoleDAL: IGenericDAL<AppRole>
    {
        Task CreateAppRoleAsync(AppRole appRole);
        Task DeleteAppRoleAsync(int id);
        Task UpdateAppRoleAsync(AppRole appRole);
    }
}
