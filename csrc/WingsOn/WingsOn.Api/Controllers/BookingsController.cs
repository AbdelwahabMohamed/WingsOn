using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Models;
using WingsOn.Domain.Booking;
using WingsOn.Domain.Contracts;

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    public class BookingsController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingsController(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        // POST api/<controller>/
        [HttpPost]
        public IActionResult Post([FromBody]BookingDto booking)
        {
            var x = _mapper.Map<Booking>(booking);
            var savedBooking = _bookingRepository.Save(x);
            return Ok(_mapper.Map<BookingDto>(savedBooking));
        }
    }
}