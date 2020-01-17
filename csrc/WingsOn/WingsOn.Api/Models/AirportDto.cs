using WingsOn.Domain.Booking;

namespace WingsOn.Api.Models
{
    public class AirportDto
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public Airport ToAirport()
        {
            return new Airport
            {
                Id= Id,
                Code = Code,
                City = City,
                Country = Country
            };
        }

        public static AirportDto FromAirport(Airport airport)
        {
            return new AirportDto
            {
                Id = airport.Id,
                City = airport.City,
                Code = airport.Code,
                Country = airport.Country
            };
        }
    }
}