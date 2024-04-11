using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.DTOs.AboutDTOs;
using HotelProject.WebUI.DTOs.AppUserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;

namespace HotelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUserController : Controller
    {
        //private readonly UserManager<AppUser> _userManager;

        //public AdminUserController(UserManager<AppUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        //public IActionResult Index()
        //{
        //    var values = _userManager.Users.ToList();
        //    return View(values);
        //}

        private readonly IHttpClientFactory _httpClientFactory;

        public AdminUserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/AppUser");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppUserDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> AppUserList() 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/AppUser/AppUserList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppUserListDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DetailsAppUser(int id) 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:31289/api/AppUser/GetUserWithRoleAndWorkLocation/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<DetailsAppUserDTO>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
