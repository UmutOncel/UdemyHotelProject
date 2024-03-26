using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIdController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                List<BookingSearchLocationVM> bookingSearchLocationVMs = new List<BookingSearchLocationVM>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", "10ca93c475msh4c39cf6059a4493p1a9021jsn4d8ff2994920" },
                        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    bookingSearchLocationVMs = JsonConvert.DeserializeObject<List<BookingSearchLocationVM>>(body);
                    return View(bookingSearchLocationVMs.Take(1).ToList());
                }
            }
            else
            {
                List<BookingSearchLocationVM> bookingSearchLocationVMs = new List<BookingSearchLocationVM>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=paris&locale=en-gb"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", "10ca93c475msh4c39cf6059a4493p1a9021jsn4d8ff2994920" },
                        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    bookingSearchLocationVMs = JsonConvert.DeserializeObject<List<BookingSearchLocationVM>>(body);
                    return View(bookingSearchLocationVMs.Take(1).ToList());
                }
            }
        }
    }
}
