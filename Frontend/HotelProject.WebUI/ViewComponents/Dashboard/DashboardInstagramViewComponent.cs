using HotelProject.WebUI.DTOs.InstagramDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class DashboardInstagramViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-scraper-2022.p.rapidapi.com/ig/info_username/?user=umutoncel91"),
                Headers =
                {
                    { "X-RapidAPI-Key", "10ca93c475msh4c39cf6059a4493p1a9021jsn4d8ff2994920" },
                    { "X-RapidAPI-Host", "instagram-scraper-2022.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                InstagramDTO instagramDTO = JsonConvert.DeserializeObject<InstagramDTO>(body);
                return View(instagramDTO);
            }
        }
    }
}
