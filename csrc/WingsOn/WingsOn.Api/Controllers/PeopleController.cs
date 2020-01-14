using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Models;
using WingsOn.Domain;
using GenderType = WingsOn.Domain.Booking.GenderType;

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
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

        // GET api/<controller>?gender=0|1
        [HttpGet]
        public IActionResult Get(Models.GenderType gender)
        {
            //Pagination!
            var passengersByGender = _peopleRepository.GetPassengersByGender((GenderType)(int)gender);
            return Ok(passengersByGender.Select(PersonDto.FromPerson));
        }

    }
}
