using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.DTOs.RegisterDTOs;
using HotelProject.WebUI.DTOs.WorkLocationDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(UserManager<AppUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;

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
                Email = addNewUserDTO.Mail,
                Gender = addNewUserDTO.Gender,
                City = addNewUserDTO.City,
                Country = addNewUserDTO.Country,
                WorkLocationId = addNewUserDTO.WorkLocationId,
                ImageUrl = addNewUserDTO.ImageUrl
            };
            //Şifre eşleştirmesi yukarıda yazılmıyor. "UserManager"ın kendi metodu olan "CreateAsync" kullanılıyor. Bu metot şifrenin Identity kriterlerine uygunluğunu denetliyor. Eğer uygunsa başarılı değilse başarısız dönüş yapıyor.
            var result = await _userManager.CreateAsync(appUser, addNewUserDTO.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ModelState.AddModelError("", "Şifreniz istenen kriterlere uygun değil!");
                ModelState.AddModelError("", "Şifreniz en az 6 karakter içermeli.");
                ModelState.AddModelError("", "Şifreniz en az 1 özel karakter içermeli.");
                ModelState.AddModelError("", "Şifreniz en az 1 büyük harf içermeli.");
                ModelState.AddModelError("", "Şifreniz en az 1 küçük harf içermeli.");
                return View();
            }
        }
    }
}
