using System.Collections.Generic;
using WingsOn.Domain.Booking;

namespace WingsOn.Domain
{
    public interface IBookingRepository : IRepository<Booking.Booking>
    {
        IEnumerable<Person> GetPassengersForFlight(string flightNumber);
    }
}