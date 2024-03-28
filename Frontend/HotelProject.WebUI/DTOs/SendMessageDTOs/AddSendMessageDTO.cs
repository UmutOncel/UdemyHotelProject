namespace HotelProject.WebUI.DTOs.SendMessageDTOs
{
    public class AddSendMessageDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string SenderName { get; set; }
        public string SenderMail { get; set; }
        public DateTime Date { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverMail { get; set; }
    }
}
