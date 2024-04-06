using HotelProject.WebUI.DTOs.RoomDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class OurRoomsViewComponent: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OurRoomsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/Room/Get3Rooms");
            if (responseMessage.IsSuccessStatusCode) 
            { 
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRoomDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
