using System.Collections.Generic;
using System.Linq;
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

        // POST api/flights/{flightNumber}/passengers
        [Fact]
        public async Task CanPostPassngerForExistingFlight()
        {
            // arrange
            var flightHttpResponseMessage = await _client.GetAsync("/api/flights/PZ696");
            var flightResponse = await flightHttpResponseMessage.Content.ReadAsStringAsync();
            var flight = JsonConvert.DeserializeObject<FlightDto>(flightResponse);
            var passenger = new Fixture().Create<PersonDto>();

            var passengerToCreatePayload = new StringContent(JsonConvert.SerializeObject(passenger), Encoding.UTF8, "application/json");

            // act
            var httpResponse = await _client.PostAsync($"/api/flights/{flight.Number}/passengers", passengerToCreatePayload);
            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // assert
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var booking = JsonConvert.DeserializeObject<BookingDto>(stringResponse);
            Assert.True(booking != null);

        }

    }
}