using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        //Include işleminden dönen veri çok büyük olduğu için hata veriyor. Bunu engellemek için API projesi içine "Microsoft.AspNetCore.Mvc.NewtonsoftJson" nuget'i yüklenir. Sonra API program.cs içine gerekli kodlar yazılır.
        [HttpGet]
        public IActionResult GetUserListWithWorkLocation() 
        {
            var values = _appUserService.TGetUserListWithWorkLocation();
            return Ok(values);
        }

        [HttpGet("AppUserList")]
        public IActionResult AppUserList() 
        {
            var values = _appUserService.TGetList();
            return Ok(values);
        }

        [HttpGet("GetUserWithRoleAndWorkLocation/{id}")]
        public async Task<IActionResult> GetUserWithRoleAndWorkLocation(int id) 
        {
            var value = await _appUserService.TGetUserWithRoleAndWorkLocation(id);
            return Ok(value);
        }
    }
}
