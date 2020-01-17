using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Models;
using WingsOn.Domain.Contracts;

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public FlightsController(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        // GET api/<controller>/PZ696/passengers
        [HttpGet("{flightNumber}/passengers")]
        public IActionResult Get(string flightNumber)
        {
            var passengersForFlight = _bookingRepository.GetPassengersForFlight(flightNumber);
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(passengersForFlight));
        }

    }
}