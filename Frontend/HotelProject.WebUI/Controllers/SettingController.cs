﻿using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.DTOs.SettingDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            SettingDTO settingDTO = new SettingDTO 
            { 
                Firstname = user.Name,
                Lastname = user.Surname,
                Email = user.Email,
                Username = user.UserName
            };
            return View(settingDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SettingDTO settingDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = settingDTO.Firstname;
            user.Surname = settingDTO.Lastname;
            user.Email = settingDTO.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, settingDTO.Password);
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Login");
        }
    }
}