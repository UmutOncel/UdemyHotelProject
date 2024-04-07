using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.DTOs.SettingDTOs
{
    public class SettingDTO
    {
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz!")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz!")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Email adresi alanı boş bırakılamaz!")]
        public string Email { get; set; }

        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı alanı boş bırakılamaz!")]
        [Compare("Password", ErrorMessage = "Şifreleriniz uyuşmuyor! Lütfen kontrol ediniz.")]
        public string ConfirmPassword { get; set; }

        public string ImageUrl { get; set; }
        public IFormFile Photo { get; set; }
    }
}
