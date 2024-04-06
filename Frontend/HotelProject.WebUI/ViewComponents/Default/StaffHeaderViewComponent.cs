using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class StaffHeaderViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()    
        {
            return View();
        }
    }
}
