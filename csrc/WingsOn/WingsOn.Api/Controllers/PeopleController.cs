using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
        public ActionResult<PersonDto> Get(int id)
        {
            var person = _peopleRepository.Get(id);
            return Ok(_mapper.Map<PersonDto>(person));
        }

        // PATCH api/<controller>/5
        [HttpPatch("{id}")]
        public ActionResult UpdatePersonEmail(int id,JsonPatchDocument<PersonToUpdateDto> patchDocument)
        {
            var person = _peopleRepository.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            var personToUpdate = _mapper.Map<PersonToUpdateDto>(person);
            patchDocument.ApplyTo(personToUpdate);

            var updatedPerson = _mapper.Map(personToUpdate, person);
            var updated =  _peopleRepository.UpdateEmail(updatedPerson.Id, updatedPerson.Email);
            return Ok(updated);
        }

        // GET api/<controller>?gender=0|1
        [HttpGet]
        public ActionResult<IEnumerable<PersonDto>> Get(Models.GenderType gender)
        {
            //TODO: implement pagination!
            var passengersByGender = _peopleRepository.GetPassengersByGender((GenderType)(int)gender);
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(passengersByGender));
        }

    }
}
