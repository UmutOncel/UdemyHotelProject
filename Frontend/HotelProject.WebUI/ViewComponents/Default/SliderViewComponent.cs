using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class SliderViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
