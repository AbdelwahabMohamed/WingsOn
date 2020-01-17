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

        public static FlightDto FromFlight(Flight flight)
        {
            return new FlightDto
            {
                Id = flight.Id,
                ArrivalAirport = AirportDto.FromAirport(flight.ArrivalAirport),
                ArrivalDate = flight.ArrivalDate,
                Carrier = AirlineDto.FromAirLine(flight.Carrier),
                DepartureAirport = AirportDto.FromAirport(flight.DepartureAirport),
                DepartureDate = flight.DepartureDate,
                Number = flight.Number,
                Price = flight.Price
            };
        }
    }
}