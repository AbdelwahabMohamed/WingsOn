using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Models;
using WingsOn.Domain;
using WingsOn.Domain.Booking;

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    public class BookingsController : Controller
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingsController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpPost]
        public IActionResult Post(BookingDto booking)
        {
            _bookingRepository.Save(booking.ToBooking());
            return Ok();
        }
    }
}