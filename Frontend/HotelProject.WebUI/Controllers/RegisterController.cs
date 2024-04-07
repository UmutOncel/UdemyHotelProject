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
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/WorkLocation");
            if (responseMessage.IsSuccessStatusCode) 
            { 
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWorkLocationDTO>>(jsonData);
                List<SelectListItem> workLocationList = (from x in values
                                                         select new SelectListItem
                                                         {
                                                             Text = x.Name,
                                                             Value = x.WorkLocationID.ToString()
                                                         }).ToList();
                ViewBag.WorkLocationList = workLocationList;
                return View();
            }
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
                City = addNewUserDTO.City,
                WorkLocationId = addNewUserDTO.WorkLocationId,
                ImageUrl = addNewUserDTO.ImageUrl
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
