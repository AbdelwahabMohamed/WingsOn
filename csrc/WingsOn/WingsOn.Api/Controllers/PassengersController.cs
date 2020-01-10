using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Models;
using WingsOn.Domain;
using WingsOn.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    public class PassengersController : Controller
    {
        private readonly IRepository<Person> _peopleRepository;

        public PassengersController(IRepository<Person> peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _peopleRepository.Get(id);
            return Ok(PersonDto.FromPerson(person));
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
