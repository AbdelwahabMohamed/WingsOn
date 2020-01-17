using System.Collections.Generic;
using WingsOn.Domain.Booking;

namespace WingsOn.Domain.Contracts
{
    public interface IBookingRepository : IRepository<Booking.Booking>
    {
        IEnumerable<Person> GetPassengersForFlight(string flightNumber);
    }
}