﻿namespace HotelProject.WebUI.Models.Staff
{
    public class UpdateStaffVM
    {
        public int StaffID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string SocialMedia1 { get; set; }
        public string SocialMedia2 { get; set; }
        public string SocialMedia3 { get; set; }
        public string Image { get; set; }
        public IFormFile Photo { get; set; }
    }
}
