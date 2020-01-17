using WingsOn.Domain.Booking;

namespace WingsOn.Api.Models
{
    public class AirlineDto
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public Airline ToAirline()
        {
            return new Airline
            {
                Id = Id,
                Address = Address,
                Code = Code,
                Name = Name
            };
        }

        public static AirlineDto FromAirLine(Airline airline)
        {
            return new AirlineDto
            {
                Id = airline.Id,
                Address = airline.Address,
                Code = airline.Code,
                Name = airline.Name
            };
        }
    }
}
