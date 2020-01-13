using Microsoft.AspNetCore.Mvc;
using WingsOn.Domain.Services;

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
        private readonly IFlightPassengersService _flightPassengersService;

        public FlightsController(IFlightPassengersService flightPassengersService)
        {
            _flightPassengersService = flightPassengersService;
        }

        // GET api/<controller>/5/passengers
        [HttpGet("{flightNumber}/passengers")]
        public IActionResult Get(string flightNumber)
        {
            return Ok(_flightPassengersService.GetPassengersForFlight(flightNumber));
        }

    }
}