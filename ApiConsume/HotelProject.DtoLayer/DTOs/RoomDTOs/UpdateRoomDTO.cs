using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.DTOs.RoomDTOs
{
    public class UpdateRoomDTO
    {
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Lütfen oda numarasını yazınız.")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "Lütfen oda görselini giriniz.")]
        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Lütfen fiyat bilgisini yazınız.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Lütfen oda başlığı bilgisini giriniz.")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen yatak sayısı bilgisini giriniz.")]
        public string BedCount { get; set; }

        [Required(ErrorMessage = "Lütfen banyo sayısı bilgisini giriniz.")]
        public string BathCount { get; set; }

        public string Wifi { get; set; }

        [Required(ErrorMessage = "Lütfen oda açıklamasını giriniz.")]
        public string Description { get; set; }
    }
}
