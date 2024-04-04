namespace HotelProject.WebUI.DTOs.AppUserDTOs
{
    public class ResultAppUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public string Department { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public int WorkLocationId { get; set; }
        public string WorkLocationName { get; set; }
    }
}
