using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
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

        [Fact(Skip = "Batch not being read yet")]
        public async Task CanPatchPerson()
        {
            // arrange
            var content = new JsonPatchDocument<PersonToUpdateDto>();
            content.Add(dto => dto.Email, "newEmail@acme.com");

            var personToUpdatePayload = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json-patch+json");

            // act
            var httpResponse = await _client.PatchAsync($"/api/people/69", personToUpdatePayload);

            // assert
            httpResponse.EnsureSuccessStatusCode();

        }


    }
}