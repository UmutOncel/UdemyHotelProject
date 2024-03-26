using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        /*
            POSTMAN'de deneme yapmak için:
        1. "+" simgesine tıkla ve "Blank collection" seç.
        2. gelen satırda "..." tıkla ve "Add Request" bas.
        3. yanda açılan kısımda metodu seç ve yan tarafına adresi yaz. (http://localhost:32513/api/Default/TestCreateToken)
        4. "Send" tıkla.
            
            Authorize işlemini kontrol etmek için:
        1. aynı işlemleri yap. Send'e tıklamadan önce "Headers" kısmını seç.
        2. Key kısmına "Authorization" yaz.
        3. Value kısmına "Bearer üretilen token" yaz.
        4. Send'e tıkla.
        
        Burada token ile giriş yaptığımız için TestAuthCreateToken action'ı çalışacak. Bu 4 işlemi yapmayıp yukarıdaki işlemleri yapsaydık token olmadığı için TestAuthCreateToken action'ını çalıştırmayacak 401 hatası verecekti.

        TestCreateToken ile oluşturan token, TestAuthCreateTokenAdmin'de kullanılmaya çalışırsa bu sefer 403 hatası verir. (token var ama buraya ulaşmaya yetkili değil. çünkü rolü admin veya visitor değil.)
         */

        [HttpGet("[action]")]
        public IActionResult TestCreateToken() 
        {
            return Ok(new CreateToken().TokenCreate());
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult TestAuthCreateToken()
        {
            return Ok("Hoşgeldiniz.");
        }

        [HttpGet("[action]")]
        public IActionResult TestCreateTokenAdmin() 
        {
            return Ok(new CreateToken().TokenCreateAdmin());
        }

        [Authorize(Roles = "Admin, Visitor")]
        [HttpGet("[action]")]
        public IActionResult TestAuthCreateTokenAdmin() 
        {
            return Ok("Role için authorize denemesi başarılı.");
        }
    }
}
