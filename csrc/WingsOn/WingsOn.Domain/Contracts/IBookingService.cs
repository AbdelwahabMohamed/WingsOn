using System.Collections.Generic;
using WingsOn.Domain.Booking;

namespace WingsOn.Domain.Contracts
{
    public interface IBookingService
    {
        IEnumerable<Person> GetPassengersForFlight(string flightNumber);
        bool FlightExists(string flightNumber);
        Booking.Booking CreatePassengerForFlight(string flightNumber, Person passenger);
    }

}