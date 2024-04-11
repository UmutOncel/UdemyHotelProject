using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        public IActionResult ErrorPageNotFound()
        {
            return View();
        }

        public IActionResult AccessDenied() 
        {
            return View();
        }
    }
}
