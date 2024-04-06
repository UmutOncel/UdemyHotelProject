using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class ServiceHeaderViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View(); 
        }
    }
}
