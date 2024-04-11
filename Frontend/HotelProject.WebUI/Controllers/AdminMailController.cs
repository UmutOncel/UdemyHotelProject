using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailVM adminMailVM)
        {
            MimeMessage mimeMessage = new MimeMessage();
                                                                   //gönderici adı, gönderici mail adresi
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "umutoncel91@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
                                                            //alıcı adı, alıcı mail adresi
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", adminMailVM.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = adminMailVM.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = adminMailVM.Subject;

            //2 adet "SmtpClient" var. Biz MailKit'e ait olanı kullanacağız.
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);   //gmail'e bağlan, gmail port numarası
            smtpClient.Authenticate("umutoncel91@gmail.com", "nblugqtzdpznctma");   //şifre alımı notlara yazıldı
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            
            return View();
        }
    }
}
