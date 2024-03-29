using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileImageController : ControllerBase
    {
        /*
         POST İŞLEMİNİ POSTMAN'DE TEST ETMEK İÇİN:
        1. yeni bir sayfa aç. metot olarak Post'u seç. Adres kısmına swagger'dan aldığın metot linkini yapıştır.
        2. "Body" -> "form-data" seç.
        3. parametre olarak aldığın ismi "Key" kısmına yaz. (file) yanında "File" seç.
        4. "Value" kısmında yüklenecek resmi seç.
        5. "Send"e bas. (201 Created - başarılı kayıt işlemi.)
         */

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm]IFormFile file) 
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "images/" + fileName);
            var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);     //dosya stream'e kopyalanır.
            return Created("", file);
        }
    }
}
