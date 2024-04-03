namespace HotelProject.WebUI.DTOs.InstagramDTOs
{
    public class InstagramDTO
    {
        public User user { get; set; }

        public class User
        {
            public int follower_count { get; set; }
            public int following_count { get; set; }
        }
    }
}
