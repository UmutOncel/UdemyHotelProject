using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.DTOs.LoginDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]    //yetkisiz kullanıcıya erişim izni verir.
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
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı ile şifre uyumsuz. Lütfen bilgilerinizi kontrol ediniz.");
                    return View();  //kullanıcı adı ile şifre eşleşmezse
                }
            }
            return View();  //boş geçilirse
        }

        public async Task<IActionResult> SignOut() 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default"); 
        }
    }
}
