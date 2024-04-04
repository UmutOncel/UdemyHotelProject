using HotelProject.WebUI.DTOs.BookingDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminBookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> ChangeBookingStatusToApproved(int id) 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageGet = await client.GetAsync($"http://localhost:31289/api/Booking/{id}");
            var jsonData = await responseMessageGet.Content.ReadAsStringAsync();
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessagePut = await client.PutAsync($"http://localhost:31289/api/Booking/ChangeBookingStatusToApproved/{id}", stringContent);
            if (responseMessagePut.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> ChangeBookingStatusToPended(int id) 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageGet = await client.GetAsync($"http://localhost:31289/api/Booking/{id}");
            var jsonData = await responseMessageGet.Content.ReadAsStringAsync();
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessagePut = await client.PutAsync($"http://localhost:31289/api/Booking/ChangeBookingStatusToPended/{id}", stringContent);
            if (responseMessagePut.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> ChangeBookingStatusToRejected(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageGet = await client.GetAsync($"http://localhost:31289/api/Booking/{id}");
            var jsonData = await responseMessageGet.Content.ReadAsStringAsync();
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessagePut = await client.PutAsync($"http://localhost:31289/api/Booking/ChangeBookingStatusToRejected/{id}", stringContent);
            if (responseMessagePut.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:31289/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateBookingDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDTO updateBookingDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:31289/api/Booking/UpdateBooking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
