using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.DTOs.AppUserDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.AdminHeader
{
    public class AdminHeaderViewComponent: ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminHeaderViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ResultAppUserListDTO appUser = new ResultAppUserListDTO 
            { 
                Name = user.Name,
                Surname = user.Surname,
                ImageUrl = user.ImageUrl
            };
            return View(appUser);
        }
    }
}
