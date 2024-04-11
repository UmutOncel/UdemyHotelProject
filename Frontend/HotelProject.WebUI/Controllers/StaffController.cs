using HotelProject.WebUI.Helpers.Images;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IImageHelper _imageHelper;

        public StaffController(IHttpClientFactory httpClientFactory, IImageHelper imageHelper)
        {
            _httpClientFactory = httpClientFactory;
            _imageHelper = imageHelper;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StaffVM>>(jsonData);    //json nesnesini StaffVM'e dönüştürdük.(yukarıda gelen veri json türünde.)
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddStaff() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffVM addStaffVM) 
        {
            addStaffVM.Image = await _imageHelper.UploadImage(addStaffVM.Name, addStaffVM.Photo, "staff");

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addStaffVM);     //addStaffVM'i json nesnesine dönüştürdük.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:31289/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            _imageHelper.Delete(addStaffVM.Image);
            return View();
        }

        public async Task<IActionResult> DeleteStaff(int id) 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:31289/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id) 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:31289/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateStaffVM>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffVM updateStaffVM) 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessagePhoto = await client.GetAsync($"http://localhost:31289/api/Staff/{updateStaffVM.StaffID}");
            var jsonDataPhoto = await responseMessagePhoto.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateStaffVM>(jsonDataPhoto);

            if (updateStaffVM.Photo == null)
            {
                updateStaffVM.Image = value.Image;
            }
            else
            {
                _imageHelper.Delete(value.Image);
                updateStaffVM.Image = await _imageHelper.UploadImage(updateStaffVM.Name, updateStaffVM.Photo, "staff");
            }

            var jsonData = JsonConvert.SerializeObject(updateStaffVM);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:31289/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
