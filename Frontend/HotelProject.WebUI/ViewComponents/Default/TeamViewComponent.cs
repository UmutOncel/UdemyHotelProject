using HotelProject.WebUI.DTOs.StaffDTOs;
using HotelProject.WebUI.DTOs.TestimonialDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class TeamViewComponent: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TeamViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultStaffDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
