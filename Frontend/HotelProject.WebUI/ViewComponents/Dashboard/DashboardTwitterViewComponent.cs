using HotelProject.WebUI.DTOs.TwitterDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class DashboardTwitterViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter154.p.rapidapi.com/user/details?username=bilgeadam"),
                Headers =
                {
                    { "X-RapidAPI-Key", "10ca93c475msh4c39cf6059a4493p1a9021jsn4d8ff2994920" },
                    { "X-RapidAPI-Host", "twitter154.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                TwitterDTO twitterDTO = JsonConvert.DeserializeObject<TwitterDTO>(body);
                return View(twitterDTO);
            }
        }
    }
}
