namespace HotelProject.WebUI.DTOs.ContactDTOs
{
    public class AddContactDTO
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int MessageCategoryId { get; set; }
    }
}
