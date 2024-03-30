using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace HotelProject.WebUI.ViewComponents.AdminContact
{
    public class AdminContactSidebarViewComponent: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactSidebarViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient();
            
            var responseMessageContact = await client.GetAsync("http://localhost:31289/api/Contact/GetContactCount");
            
            var responseMessageSendMessage = await client.GetAsync("http://localhost:31289/api/SendMessage/GetSendMessageCount");
            
            if (responseMessageContact.IsSuccessStatusCode && responseMessageSendMessage.IsSuccessStatusCode)
            {
                var jsonDataContact = await responseMessageContact.Content.ReadAsStringAsync();
                ViewBag.ContactCount = jsonDataContact;

                var jsonDataSendMessage = await responseMessageSendMessage.Content.ReadAsStringAsync();
                ViewBag.SendMessageCount = jsonDataSendMessage;
                
                return View();
            }
            return View();
        }
    }
}
