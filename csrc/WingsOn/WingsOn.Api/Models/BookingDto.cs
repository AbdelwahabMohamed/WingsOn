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

        public static BookingDto FromBooking(Booking booking)
        {
            return new BookingDto
            {
                Id = booking.Id,
                Customer = PersonDto.FromPerson(booking.Customer),
                DateBooking = booking.DateBooking,
                Flight = FlightDto.FromFlight(booking.Flight),
                Number = booking.Number, 
                Passengers = booking.Passengers.Select(PersonDto.FromPerson)
            };
        }

        public Booking ToBooking()
        {
            return new Booking
            {
                Id = Id,
                Number = Number,
                Flight = Flight.ToFlight(),
                Customer = Customer.ToPerson(),
                DateBooking = DateBooking,
                Passengers = Passengers.Select(s => s.ToPerson())
            };
        }
    }
}