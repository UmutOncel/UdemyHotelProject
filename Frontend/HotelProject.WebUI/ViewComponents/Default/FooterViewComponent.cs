using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class FooterViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View();
        }
    }
}
