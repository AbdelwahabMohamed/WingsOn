using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using WingsOn.Api;
using WingsOn.Api.Models;
using Xunit;

namespace WingsOn.Tests
{
    [Collection("Application collection")]
    public class PeopleControllerTests
    {
        private readonly HttpClient _client;
        public PeopleControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanGetPersonById()
        {
            // arrange

            // act
            var httpResponse = await _client.GetAsync("/api/people/69");

            // assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var person = JsonConvert.DeserializeObject<PersonDto>(stringResponse);
            Assert.True(person.Id == 69);
        }

        [Fact]
        public async Task CanGetPersonByGender()
        {
            // arrange
            var gender = new Fixture().Create<GenderType>();
            // act
            var httpResponse = await _client.GetAsync($"/api/people?gender={gender}");

            // assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var peopleByGender = JsonConvert.DeserializeObject<IEnumerable<PersonDto>>(stringResponse);
            Assert.All(peopleByGender, p => Assert.True(p.Gender == gender));
        }
        [Fact]
        public async Task CanPutPerson()
        {
            // arrange
            var personHttpResponseMessage = await _client.GetAsync("/api/people/69");
            var personResponse = await personHttpResponseMessage.Content.ReadAsStringAsync();
            var personToUpdate = JsonConvert.DeserializeObject<PersonDto>(personResponse);
            var newEmail = new Fixture().Create<string>();
            personToUpdate.Email = newEmail;
            var personToUpdatePayload = new StringContent(JsonConvert.SerializeObject(personToUpdate), Encoding.UTF8, "application/json");

            // act
            var httpResponse = await _client.PutAsync($"/api/people/", personToUpdatePayload);

            // assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var peopleByGender = JsonConvert.DeserializeObject<PersonDto>(stringResponse);
            Assert.True(personToUpdate.Email == newEmail);
        }


    }
}