using System;
using WingsOn.Domain.Booking;

namespace WingsOn.Api.Models
{
    public class FlightDto
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public AirlineDto Carrier { get; set; }

        public AirportDto DepartureAirport { get; set; }

        public DateTime DepartureDate { get; set; }

        public AirportDto ArrivalAirport { get; set; }

        public DateTime ArrivalDate { get; set; }

        public decimal Price { get; set; }

        public Flight ToFlight()
        {
            return new Flight
            {
                Id = Id,
                ArrivalAirport = ArrivalAirport.ToAirport(),
                ArrivalDate = ArrivalDate,
                Carrier = Carrier.ToAirline(),
                DepartureAirport = DepartureAirport.ToAirport(),
                DepartureDate = DepartureDate,
                Number = Number,
                Price = Price
            };
        }
    }
}