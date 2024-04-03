using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.DTOs.AppRoleDTOs
{
    public class AddAppRoleDTO
    {
        [Required(ErrorMessage = "Rol adı alanı boş bırakılamaz.")]
        public string Name { get; set; }
    }
}
