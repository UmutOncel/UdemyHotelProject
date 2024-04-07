using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.DTOs.SettingDTOs;
using HotelProject.WebUI.Helpers.Images;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IImageHelper _imageHelper;

        public SettingController(UserManager<AppUser> userManager, IImageHelper imageHelper)
        {
            _userManager = userManager;
            _imageHelper = imageHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            SettingDTO settingDTO = new SettingDTO 
            { 
                Firstname = user.Name,
                Lastname = user.Surname,
                Email = user.Email,
                Username = user.UserName,
                ImageUrl = user.ImageUrl
            };
            return View(settingDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SettingDTO settingDTO)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (settingDTO.Photo != null)
            {
                user.ImageUrl = await _imageHelper.UploadImage(settingDTO.Username, settingDTO.Photo, "appUser");
            }

            user.Name = settingDTO.Firstname;
            user.Surname = settingDTO.Lastname;
            user.Email = settingDTO.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, settingDTO.Password);
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Login");
        }
    }
}
