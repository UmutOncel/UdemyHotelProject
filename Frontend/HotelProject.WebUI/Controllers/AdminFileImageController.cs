using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelProject.WebUI.Controllers
{
    public class AdminFileImageController : Controller
    {
        [HttpGet]
        public IActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var stream = new MemoryStream();        //akış oluşturuldu.
            await file.CopyToAsync(stream);         //dosya stream'e kopyalandı.
            var bytes = stream.ToArray();           //stream diziye çevrildi.

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);

            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("http://localhost:31289/api/FileImage", multipartFormDataContent);

            return View();
        }
    }
}
