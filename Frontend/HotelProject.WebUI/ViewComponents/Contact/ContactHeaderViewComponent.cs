using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Contact
{
    public class ContactHeaderViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View();
        }
    }
}
