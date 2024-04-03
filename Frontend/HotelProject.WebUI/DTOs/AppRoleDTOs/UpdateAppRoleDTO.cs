using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.DTOs.AppRoleDTOs
{
    public class UpdateAppRoleDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Rol adı alanı boş bırakılamaz.")]
        public string Name { get; set; }
    }
}
