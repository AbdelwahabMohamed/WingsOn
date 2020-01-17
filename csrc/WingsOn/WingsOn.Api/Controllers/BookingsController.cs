using System.Linq;
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
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingsController(IRepository<Booking> bookingRepository, IMapper mapper, IBookingService bookingService, IFlightRepository flightRepository)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _bookingService = bookingService;
            _flightRepository = flightRepository;
        }
        // GET api/<controller>/{nuber}
        [HttpGet("{number}", Name = "GetBooking")]
        public IActionResult Get(string number)
        {
            var booking = _bookingRepository.GetAll().First(b => b.Number == number);
            return Ok(_mapper.Map<BookingDto>(booking));
        }

        //POST api/bookings/flights/{flightNumber}/passengers
        [HttpPost("flights/{flightNumber}/passengers")]
        public IActionResult Post(string flightNumber, PersonDto passenger)
        {
            if (!_flightRepository.FlightExists(flightNumber))
            {
                return NotFound(flightNumber);
            }

            var savedBooking = _bookingService.CreateBookingForNewPassengerForExistingFlight(flightNumber, _mapper.Map<Person>(passenger));
        
            return CreatedAtRoute(
                "GetBooking",
                new { Number = savedBooking.Number },
                _mapper.Map<BookingDto>(savedBooking));
        }
    }
}