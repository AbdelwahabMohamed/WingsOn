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
        private readonly IMapper _mapper;

        public BookingsController(IRepository<Booking> bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }
        // GET api/<controller>/{id}
        [HttpGet("{number}", Name = "GetBooking")]
        public IActionResult Get(string number)
        {
            //TODO: refactor data layer  not to load all entities in memory for searching 
            var booking = _bookingRepository.GetAll().First(b => b.Number == number);
            return Ok(_mapper.Map<BookingDto>(booking));
        }
    }
}