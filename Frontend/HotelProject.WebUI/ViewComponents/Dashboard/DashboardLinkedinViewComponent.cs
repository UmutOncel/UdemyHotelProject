using HotelProject.WebUI.DTOs.LinkedinDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class DashboardLinkedinViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://linkedin-api8.p.rapidapi.com/connection-count?username=umut-%C3%B6ncel-1b3194a6"),
                Headers =
                {
                    { "X-RapidAPI-Key", "10ca93c475msh4c39cf6059a4493p1a9021jsn4d8ff2994920" },
                    { "X-RapidAPI-Host", "linkedin-api8.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                LinkedinDTO linkedinDTO = JsonConvert.DeserializeObject<LinkedinDTO>(body);
                return View(linkedinDTO);
            }
        }
    }
}
