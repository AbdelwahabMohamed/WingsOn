using System;
using System.Collections.Generic;
using System.Linq;
using WingsOn.Domain.Booking;

namespace WingsOn.Api.Models
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public FlightDto Flight { get; set; }

        public PersonDto Customer { get; set; }

        public IEnumerable<PersonDto> Passengers { get; set; }

        public DateTime DateBooking { get; set; }

        public  Booking ToBooking()
        {
            return new Booking
            {
                Id = Id,
                Number = Number,
                Flight = Flight.ToFlight(),
                Customer = Customer.ToPerson(),
                DateBooking = DateBooking,
                Passengers = Passengers.Select(s=>s.ToPerson())
            };
        }
    }
}