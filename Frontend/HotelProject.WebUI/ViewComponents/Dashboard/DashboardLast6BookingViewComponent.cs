using HotelProject.WebUI.DTOs.BookingDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class DashboardLast6BookingViewComponent: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardLast6BookingViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/Dashboard/GetLast6Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast6BookingDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
