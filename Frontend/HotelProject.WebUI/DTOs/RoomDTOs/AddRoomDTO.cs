using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.DTOs.RoomDTOs
{
    public class AddRoomDTO
    {
        [Required(ErrorMessage = "Oda numarası boş bırakılamaz.")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "Oda görseli boş bırakılamaz.")]
        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Oda görseli boş bırakılamaz.")]
        public IFormFile Image { get; set; }    //yüklenen resmi yakalamak için.

        [Required(ErrorMessage = "Oda ücreti boş bırakılamaz.")]
        public int? Price { get; set; }

        [Required(ErrorMessage = "Oda başlığı boş bırakılamaz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Yatak sayısı boş bırakılamaz.")]
        public string BedCount { get; set; }

        [Required(ErrorMessage = "Banyo sayısı boş bırakılamaz.")]
        public string BathCount { get; set; }

        [Required(ErrorMessage = "Wifi boş bırakılamaz.")]
        public string Wifi { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        public string Description { get; set; }
    }
}
