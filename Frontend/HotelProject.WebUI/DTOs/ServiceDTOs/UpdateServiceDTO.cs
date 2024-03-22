using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.DTOs.ServiceDTOs
{
    public class UpdateServiceDTO
    {
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Hizmet ikon linki girmek zorunludur.")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet başlığı girmek zorunludur.")]
        [StringLength(100, ErrorMessage = "Hizmet başlığı 100 karakterden fazla olamaz!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Hizmet açıklaması girmek zorunludur.")]
        [StringLength(500, ErrorMessage = "Hizmet açıklaması 500 karakterden fazla olamaz!")]
        public string Description { get; set; }
    }
}
