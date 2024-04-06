using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class RoomHeaderViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View(); 
        }
    }
}
