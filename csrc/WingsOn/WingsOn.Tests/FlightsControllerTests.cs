using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using WingsOn.Api;
using WingsOn.Api.Models;
using Xunit;

namespace WingsOn.Tests
{
    [Collection("Application collection")]
    public class FlightsControllerTests
    {
        private readonly HttpClient _client;
        public FlightsControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }


        [Fact]
        public async Task CanGetFlightByNumber()
        {
            // arrange

            // act
            var httpResponse = await _client.GetAsync("/api/flights/PZ696/");

            // assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var flight = JsonConvert.DeserializeObject<FlightDto>(stringResponse);
            Assert.True(flight.Number == "PZ696");
        }


        [Fact]
        public async Task CanGetPassengers()
        {
            // arrange

            // act
            var httpResponse = await _client.GetAsync("/api/flights/PZ696/passengers");

            // assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var passengers = JsonConvert.DeserializeObject<IEnumerable<PersonDto>>(stringResponse);
            Assert.True(passengers.Any());
        }

    }
}