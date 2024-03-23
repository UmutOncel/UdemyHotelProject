using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.DTOs.LoginDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDTO loginUserDTO)
        {
            if (ModelState.IsValid)
            {
                //3. parametre: "isPersistent" = şifre tarayıcıda saklansın mı?
                //4. paramete: "lockoutOnFailure" = kullanıcı art arda yanlış 5 giriş yapınca sistem belli süre (5 dakika) tekrar login olmasını engelliyor. (database'deki "AccessFailedCount" sütununda tutuluyor.)
                var result = await _signInManager.PasswordSignInAsync(loginUserDTO.Username, loginUserDTO.Password, true, true);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Index", "Staff");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}
