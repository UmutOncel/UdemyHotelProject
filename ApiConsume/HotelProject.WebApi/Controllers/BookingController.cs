using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public ActionResult BookingList() 
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking) 
        {
            _bookingService.TInsert(booking);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id) 
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok();
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking) 
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }

        [HttpPut("ChangeBookingStatusToApproved/{id}")]
        public IActionResult ChangeBookingStatusToApproved(int id) 
        {
            _bookingService.TChangeBookingStatusToApproved(id);
            return Ok();
        }

        [HttpPut("ChangeBookingStatusToPended/{id}")]
        public IActionResult ChangeBookingStatusToPended(int id) 
        {
            _bookingService.TChangeBookingStatusToPended(id);
            return Ok();
        }

        [HttpPut("ChangeBookingStatusToRejected/{id}")]
        public IActionResult ChangeBookingStatusToRejected(int id)
        {
            _bookingService.TChangeBookingStatusToRejected(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id) 
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);
        }
    }
}
