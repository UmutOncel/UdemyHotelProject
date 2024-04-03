using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class DashboardHeadViewComponent: ViewComponent 
    {
        public IViewComponentResult Invoke() 
        { 
            return View();
        }
    }
}
