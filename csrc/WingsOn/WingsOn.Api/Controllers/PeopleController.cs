using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Models;
using WingsOn.Domain;
using WingsOn.Domain.Entities;
using WingsOn.Domain.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IRepository<Person> _peopleRepository;
        private readonly IFlightPassengersService _flightPassengersService;

        public PeopleController(IRepository<Person> peopleRepository, IFlightPassengersService flightPassengersService)
        {
            _peopleRepository = peopleRepository;
            _flightPassengersService = flightPassengersService;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _peopleRepository.Get(id);
            return Ok(PersonDto.FromPerson(person));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PersonDto person)
        {
            _peopleRepository.Save(person.ToPerson());
            return Ok();
        }
        // GET api/<controller>/5
        [HttpGet]
        public IActionResult Get(Models.GenderType gender)
        {
            var passengersByGender = _flightPassengersService.GetPassengersByGender((Domain.Entities.GenderType)(int)gender);
            return Ok(passengersByGender);
        }

    }
}
