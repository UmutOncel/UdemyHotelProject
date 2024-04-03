using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;

        public DashboardController(IStaffService staffService, IBookingService bookingService, IAppUserService appUserService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _appUserService = appUserService;
            _roomService = roomService;
        }

        [HttpGet("GetStaffCount")]
        public IActionResult GetStaffCount() 
        {
            var value = _staffService.TGetStaffCount();
            return Ok(value);
        }

        [HttpGet("GetBookingCount")]
        public IActionResult GetBookingCount() 
        {
            var value = _bookingService.TGetBookingCount();
            return Ok(value);
        }

        [HttpGet("GetAppUserCount")]
        public IActionResult GetAppUserCount()
        {
            var value = _appUserService.TGetAppUserCount();
            return Ok(value);
        }

        [HttpGet("GetRoomCount")]
        public IActionResult GetRoomCount()
        {
            var value = _roomService.TGetRoomCount();
            return Ok(value);
        }

        [HttpGet("GetLast4Staff")]
        public IActionResult GetLast4Staff()
        {
            var values = _staffService.TGetLast4Staff();
            return Ok(values);
        }

        [HttpGet("GetLast6Booking")]
        public IActionResult GetLast6Booking()
        {
            var values = _bookingService.TGetLast6Booking();
            return Ok(values);
        }
    }
}
