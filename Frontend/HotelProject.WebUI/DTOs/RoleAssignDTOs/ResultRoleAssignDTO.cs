namespace HotelProject.WebUI.DTOs.RoleAssignDTOs
{
    public class ResultRoleAssignDTO
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsRoleExist { get; set; }
        public int UserId { get; set; }
    }
}
