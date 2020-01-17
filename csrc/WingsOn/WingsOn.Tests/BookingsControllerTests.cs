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
    public class BookingsControllerTests 
    {
        private readonly HttpClient _client;
        public BookingsControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanGetBooking()
        {
            //arrange
            // act
            var httpResponse = await _client.GetAsync("/api/Bookings/WO-291470");
            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // assert
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var booking = JsonConvert.DeserializeObject<BookingDto>(stringResponse);
            Assert.True(booking.Number== "WO-291470");
        }

        //POST api/bookings/flights/{flightNumber}/passengers
        [Fact]
        public async Task CanPostBookingForNewPassngerForExistingFlight()
        {
            // arrange
            var flightHttpResponseMessage = await _client.GetAsync("/api/flights/PZ696");
            var flightResponse = await flightHttpResponseMessage.Content.ReadAsStringAsync();
            var flight = JsonConvert.DeserializeObject<FlightDto>(flightResponse);
            var passenger = new Fixture().Create<PersonDto>();

            var passengerToCreatePayload = new StringContent(JsonConvert.SerializeObject(passenger), Encoding.UTF8, "application/json");

            // act
            var httpResponse = await _client.PostAsync($"/api/bookings/flights/{flight.Number}/passengers", passengerToCreatePayload);
            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // assert
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var booking = JsonConvert.DeserializeObject<BookingDto>(stringResponse);
            Assert.True(booking != null);

        }
    }
}