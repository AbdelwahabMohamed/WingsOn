using System;

namespace WingsOn.Domain.Entities
{
    public class Flight : DomainObject
    {
        public string Number { get; set; }

        public Airline Carrier { get; set; }

        public Airport DepartureAirport { get; set; }

        public DateTime DepartureDate { get; set; }

        public Airport ArrivalAirport { get; set; }

        public DateTime ArrivalDate { get; set; }

        public decimal Price { get; set; }
    }
}