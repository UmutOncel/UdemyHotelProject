using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class ReservationViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        }
    }
}
