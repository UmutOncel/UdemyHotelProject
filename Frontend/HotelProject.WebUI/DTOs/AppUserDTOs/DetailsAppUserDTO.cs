namespace HotelProject.WebUI.DTOs.AppUserDTOs
{
    public class DetailsAppUserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public List<string> WorkLocationName { get; set; }
        public List<string> AppRoles { get; set; }
    }
}
