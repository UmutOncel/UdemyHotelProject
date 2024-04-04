using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.DTOs.AppRoleDTOs;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppRoleController : ControllerBase
    {
        private readonly IAppRoleService _appRoleService;

        public AppRoleController(IAppRoleService appRoleService)
        {
            _appRoleService = appRoleService;
        }

        [HttpGet]
        public IActionResult AppRoleList() 
        {
            var values = _appRoleService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddAppRole(AppRole appRole)
        {
            _appRoleService.TInsert(appRole);
            return Ok();
        }

        [HttpPost("CreateAppRoleAsync")]
        public async Task<IActionResult> CreateAppRoleAsync(AppRole appRole)
        {
            await _appRoleService.TCreateAppRoleAsync(appRole);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppRole(int id) 
        {
            var value = _appRoleService.TGetByID(id);
            _appRoleService.TDelete(value);
            return Ok();
        }

        [HttpDelete("DeleteAppRoleAsync/{id}")]
        public async Task<IActionResult> DeleteAppRoleAsync(int id) 
        {
            await _appRoleService.TDeleteAppRoleAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetAppRole(int id)
        {
            var value = _appRoleService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateAppRole(AppRole appRole) 
        {
            _appRoleService.TUpdate(appRole);
            return Ok();
        }

        [HttpPut("UpdateAppRoleAsync")]
        public async Task<IActionResult> UpdateAppRoleAsync(AppRole appRole)
        {
            await _appRoleService.TUpdateAppRoleAsync(appRole);
            return Ok();
        }

        [HttpGet("GetAssignRoleAsync/{id}")]
        public async Task<IActionResult> GetAssignRoleAsync(int id) 
        { 
            var values = await _appRoleService.TGetAssignRoleAsync(id);
            return Ok(values);
        }

        [HttpPost("PostAssignRoleAsync")]
        public async Task<IActionResult> PostAssignRoleAsync(List<RoleAssignDTO> roleList)
        {
            await _appRoleService.TPostAssignRoleAsync(roleList);
            return Ok();
        }
    }
}
