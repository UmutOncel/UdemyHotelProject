using HotelProject.WebUI.DTOs.AboutDTOs;
using HotelProject.WebUI.DTOs.RoomDTOs;
using HotelProject.WebUI.Helpers.Images;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminRoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IImageHelper _imageHelper;

        public AdminRoomController(IHttpClientFactory httpClientFactory, IImageHelper imageHelper)
        {
            _httpClientFactory = httpClientFactory;
            _imageHelper = imageHelper;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/Room");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRoomDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> RoomDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:31289/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<DetailsRoomDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddRoom() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(AddRoomDTO addRoomDTO) 
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            addRoomDTO.RoomCoverImage = await _imageHelper.UploadImage(addRoomDTO.Title, addRoomDTO.Image, "room");

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addRoomDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:31289/api/Room", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            //UploadImage işlemi sonunda resim wwwroot'a kaydedilir. Eğer responseMessage başarısız dönerse resim wwwroot'a kayıtlı fakat nesne oluşmamış olur. Dolayısıyla resim başıboş kalır. Bunu önlemek için responseMessage başarısız ise resmi sileriz.
            _imageHelper.Delete(addRoomDTO.RoomCoverImage);
            return View();
        }

        public async Task<IActionResult> DeleteRoom(int id) 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:31289/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:31289/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateRoomDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRoom(UpdateRoomDTO updateRoomDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageImage = await client.GetAsync($"http://localhost:31289/api/Room/{updateRoomDTO.RoomID}");
            var jsonDataImage = await responseMessageImage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateRoomDTO>(jsonDataImage);

            if (updateRoomDTO.Image == null)
            {
                updateRoomDTO.RoomCoverImage = value.RoomCoverImage;
            }
            else
            {
                //eski resmi sil, yenisini yükle.
                _imageHelper.Delete(value.RoomCoverImage);
                updateRoomDTO.RoomCoverImage = await _imageHelper.UploadImage(updateRoomDTO.Title, updateRoomDTO.Image, "room");
            }
            
            var jsonData = JsonConvert.SerializeObject(updateRoomDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:31289/api/Room", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
