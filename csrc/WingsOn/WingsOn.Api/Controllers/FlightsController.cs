using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Models;
using WingsOn.Domain.Contracts;

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;

        public FlightsController(IBookingService bookingService, IMapper mapper, IFlightRepository flightRepository)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _flightRepository = flightRepository;
        }

        // GET api/<controller>/PZ696
        [HttpGet("{flightNumber}")]
        public ActionResult<FlightDto> Get(string flightNumber)
        {
            var flight = _flightRepository.GetAll().FirstOrDefault(f=>f.Number == flightNumber);
            return Ok(_mapper.Map<FlightDto>(flight));
        }

        // GET api/<controller>/PZ696/passengers
        [HttpGet("{flightNumber}/passengers")]
        public ActionResult<IEnumerable<PersonDto>> GetPassengers(string flightNumber)
        {
            var passengersForFlight = _bookingService.GetPassengersForFlight(flightNumber);
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(passengersForFlight));
        }
    }
}