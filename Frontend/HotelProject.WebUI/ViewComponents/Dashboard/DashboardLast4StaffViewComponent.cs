using HotelProject.WebUI.DTOs.StaffDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class DashboardLast4StaffViewComponent: ViewComponent 
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardLast4StaffViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/Dashboard/GetLast4Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast4StaffDTO>>(jsonData);
                return View(values);
            }
            return View(); 
        }
    }
}
