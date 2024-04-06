using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class TestimonialHeaderViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View();
        }
    }
}
