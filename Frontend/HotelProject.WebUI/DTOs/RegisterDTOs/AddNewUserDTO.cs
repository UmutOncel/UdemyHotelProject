using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.DTOs.RegisterDTOs
{
    public class AddNewUserDTO
    {
        [Required(ErrorMessage = "İsim alanı boş bırakılamaz!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim alanı boş bırakılamaz!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı alanı boş bırakılamaz!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mail adresi alanı boş bırakılamaz!")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı alanı boş bırakılamaz!")]
        [Compare("Password", ErrorMessage = "Şifreleriniz uyuşmuyor! Lütfen kontrol ediniz.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Şehir alanı boş bırakılamaz!")]
        public string City { get; set; }

        [Required(ErrorMessage = "Ülke alanı boş bırakılamaz!")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Cinsiyet alanı boş bırakılamaz!")]
        public string Gender { get; set; }

        public int WorkLocationId { get; set; } = 6;

        public string ImageUrl { get; set; } = "/adminweb/images/avatar/Profil Pic.jpg";

        public int RoleId { get; set; } = 14;
    }
}
