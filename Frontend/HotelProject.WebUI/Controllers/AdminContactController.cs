using HotelProject.WebUI.DTOs.ContactDTOs;
using HotelProject.WebUI.DTOs.SendMessageDTOs;
using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()    //Gelen kutusu
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public PartialViewResult AdminContactCategorySidebarPartial() 
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult AddSendMessage() 
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSendMessage(AddSendMessageDTO addSendMessageDTO)
        {
            addSendMessageDTO.SenderMail = "umutoncel91@gmail.com";
            addSendMessageDTO.SenderName = "HotelierAdmin";

            MimeMessage mimeMessage = new MimeMessage();
                                                                   
            MailboxAddress mailboxAddressFrom = new MailboxAddress(addSendMessageDTO.SenderName, addSendMessageDTO.SenderMail);     //gönderici adı, gönderici mail adresi
            mimeMessage.From.Add(mailboxAddressFrom);
                                                            
            MailboxAddress mailboxAddressTo = new MailboxAddress(addSendMessageDTO.ReceiverName, addSendMessageDTO.ReceiverMail);   //alıcı adı, alıcı mail adresi
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = addSendMessageDTO.Content;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = addSendMessageDTO.Title;

            //2 adet "SmtpClient" var. Biz MailKit'e ait olanı kullanacağız.
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);   //gmail'e bağlan, gmail port numarası
            smtpClient.Authenticate("umutoncel91@gmail.com", "nblugqtzdpznctma");   //şifre alımı notlara yazıldı
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            addSendMessageDTO.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addSendMessageDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:31289/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Sendbox");
            }
            return View();
        }

        public async Task<IActionResult> Sendbox()      //Gönderilen kutusu
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<SendboxSendMessageDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> InboxMessageDetails(int id) 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:31289/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<DetailsContactDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        public async Task<IActionResult> SendboxMessageDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:31289/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<DetailsSendboxMessageDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        public async Task<IActionResult> GetContactsInCategoryThank() 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/Contact/GetContactsInCategoryThank");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> GetContactsInCategoryComplaint()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/Contact/GetContactsInCategoryComplaint");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> GetContactsInCategoryDemand()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/Contact/GetContactsInCategoryDemand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> GetContactsInCategoryJobApplication()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/Contact/GetContactsInCategoryJobApplication");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> GetContactsInCategoryOther()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/Contact/GetContactsInCategoryOther");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> GetContactsInCategorySuggestion()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:31289/api/Contact/GetContactsInCategorySuggestion");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
