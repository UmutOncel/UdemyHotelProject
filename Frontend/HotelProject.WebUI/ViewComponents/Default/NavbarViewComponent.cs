using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class NavbarViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
