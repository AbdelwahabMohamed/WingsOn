using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Models;
using WingsOn.Domain.Contracts;

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
        private readonly IBookingRepository _bookingRepository;

        public FlightsController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        // GET api/<controller>/PZ696/passengers
        [HttpGet("{flightNumber}/passengers")]
        public IActionResult Get(string flightNumber)
        {
            var passengersForFlight = _bookingRepository.GetPassengersForFlight(flightNumber);
            var passengersDto = passengersForFlight.Select(PersonDto.FromPerson);
            return Ok(passengersDto);
        }

    }
}