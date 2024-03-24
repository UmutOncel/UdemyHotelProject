using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class HeadViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
