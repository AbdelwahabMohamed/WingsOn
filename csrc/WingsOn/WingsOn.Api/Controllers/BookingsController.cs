using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Models;
using WingsOn.Domain.Contracts;

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

        // POST api/<controller>/
        [HttpPost]
        public IActionResult Post([FromBody]BookingDto booking)
        {
            var saved = _bookingRepository.Save(booking.ToBooking());
            return Ok(BookingDto.FromBooking(saved));
        }
    }
}