using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.DTOs.RoomDTOs
{
    public class AddRoomDTO
    {
        [Required(ErrorMessage = "Lütfen oda numarasını yazınız.")]
        public string RoomNumber { get; set; }

        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Lütfen fiyat bilgisini yazınız.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Lütfen oda başlığı bilgisini giriniz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen yatak sayısı bilgisini giriniz.")]
        public string BedCount { get; set; }

        [Required(ErrorMessage = "Lütfen banyo sayısı bilgisini giriniz.")]
        public string BathCount { get; set; }

        public string Wifi { get; set; }

        public string Description { get; set; }
    }
}
