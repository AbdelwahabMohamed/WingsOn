using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Models;
using WingsOn.Domain.Booking;
using WingsOn.Domain.Contracts;
using GenderType = WingsOn.Domain.Booking.GenderType;

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IMapper _mapper;

        public PeopleController(IPeopleRepository peopleRepository, IMapper mapper)
        {
            _peopleRepository = peopleRepository;
            _mapper = mapper;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _peopleRepository.Get(id);
            return Ok(_mapper.Map<PersonDto>(person));
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Put([FromBody] PersonDto person)
        {
            var updatedPerson = _peopleRepository.Save(_mapper.Map<Person>(person));
            return Ok(updatedPerson);
        }

        // GET api/<controller>?gender=0|1
        [HttpGet]
        public IActionResult Get(Models.GenderType gender)
        {
            //TODO: implement pagination!
            var passengersByGender = _peopleRepository.GetPassengersByGender((GenderType)(int)gender);
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(passengersByGender));
        }

    }
}
