using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Models;
using WingsOn.Domain.Booking;
using WingsOn.Domain.Contracts;

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IRepository<Flight> _flightRepository;
        private readonly IMapper _mapper;

        public FlightsController(IBookingService bookingService, IMapper mapper, IRepository<Flight> flightRepository)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _flightRepository = flightRepository;
        }

        // GET api/<controller>/PZ696
        [HttpGet("{flightNumber}")]
        public IActionResult Get(string flightNumber)
        {
            var flight = _flightRepository.GetAll().FirstOrDefault(f=>f.Number == flightNumber);
            return Ok(_mapper.Map<FlightDto>(flight));
        }

        // GET api/<controller>/PZ696/passengers
        [HttpGet("{flightNumber}/passengers")]
        public IActionResult GetPassengers(string flightNumber)
        {
            var passengersForFlight = _bookingService.GetPassengersForFlight(flightNumber);
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(passengersForFlight));
        }

        //// POST api/flights/{flightNumber}/passengers
        //[HttpPost("{flightNumber}/passengers")]
        //public IActionResult Post(string flightNumber, PersonDto passenger)
        //{
        //    if (!_bookingService.FlightExists(flightNumber))
        //    {
        //        return NotFound(flightNumber);
        //    }

        //    var savedBooking = _bookingService.CreatePassengerForFlight(flightNumber,_mapper.Map<Person>(passenger));
        //    return CreatedAtRoute(
        //        "GetBooking",
        //        new { Number = savedBooking.Number },
        //        _mapper.Map<BookingDto>(savedBooking));
        //}

    }
}