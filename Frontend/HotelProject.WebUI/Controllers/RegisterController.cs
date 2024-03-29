using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.DTOs.RegisterDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AddNewUserDTO addNewUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var appUser = new AppUser() 
            { 
                Name = addNewUserDTO.Name,
                Surname = addNewUserDTO.Surname,
                UserName = addNewUserDTO.Username,
                Email = addNewUserDTO.Mail
            };
            //Şifre eşleştirmesi yukarıda yazılmıyor. "UserManager"ın kendi metodu olan "CreateAsync" kullanılıyor.
            var result = await _userManager.CreateAsync(appUser, addNewUserDTO.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
