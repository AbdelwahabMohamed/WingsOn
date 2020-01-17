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
    }
}