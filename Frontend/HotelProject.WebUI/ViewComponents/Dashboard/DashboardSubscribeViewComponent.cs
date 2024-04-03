using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class DashboardSubscribeViewComponent: ViewComponent 
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        }
    }
}
