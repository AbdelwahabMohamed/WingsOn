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
    public class BookingsControllerTests 
    {
        private readonly HttpClient _client;
        public BookingsControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanPostBooking()
        {
            //arrange
            var newBooking = new Fixture().Create<BookingDto>();
            var bookingPayload = new StringContent(JsonConvert.SerializeObject(newBooking), Encoding.UTF8, "application/json");

            // act
            var httpResponse = await _client.PostAsync("/api/Bookings/", bookingPayload);
            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // assert
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var booking = JsonConvert.DeserializeObject<BookingDto>(stringResponse);
            Assert.True(booking.Passengers.Any());
        }
    }
}