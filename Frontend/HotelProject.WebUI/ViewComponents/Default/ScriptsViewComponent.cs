using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class ScriptsViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        } 
    }
}
