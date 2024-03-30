using HotelProject.WebUI.DTOs.ContactDTOs;
using HotelProject.WebUI.DTOs.MessageCategoryDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/MessageCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDTO>>(jsonData);
                List<SelectListItem> messageCategoryList = (from x in values
                                                            select new SelectListItem
                                                            {
                                                                Text = x.Name,
                                                                Value = x.MessageCategoryID.ToString()
                                                            }).ToList();
                ViewBag.categoryList = messageCategoryList;
                return View();
            }
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage() 
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(AddContactDTO addContactDTO) 
        {
            addContactDTO.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addContactDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:31289/api/Contact", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
