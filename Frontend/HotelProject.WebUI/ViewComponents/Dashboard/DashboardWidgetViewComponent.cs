using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class DashboardWidgetViewComponent: ViewComponent 
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardWidgetViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseStaff = await client.GetAsync("http://localhost:31289/api/Dashboard/GetStaffCount");

            var responseBooking = await client.GetAsync("http://localhost:31289/api/Dashboard/GetBookingCount");

            var responseAppUser = await client.GetAsync("http://localhost:31289/api/Dashboard/GetAppUserCount");

            var responseRoom = await client.GetAsync("http://localhost:31289/api/Dashboard/GetRoomCount");

            if (responseStaff.IsSuccessStatusCode && responseBooking.IsSuccessStatusCode)
            {
                var jsonStaff = await responseStaff.Content.ReadAsStringAsync();
                ViewBag.StaffCount = jsonStaff;  //jsonData içinde sadece tek veri döndüğü için deserilize işlemi yapmadık.

                var jsonBooking = await responseBooking.Content.ReadAsStringAsync();
                ViewBag.BookingCount = jsonBooking;

                var jsonAppUser = await responseAppUser.Content.ReadAsStringAsync();
                ViewBag.AppUserCount = jsonAppUser;

                var jsonRoom = await responseRoom.Content.ReadAsStringAsync();
                ViewBag.RoomCount = jsonRoom;

                return View();
            }
            return View();
        }
    }
}
