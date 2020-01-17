using WingsOn.Domain.Booking;

namespace WingsOn.Domain.Contracts
{
    public interface IFlightRepository : IRepository<Flight>
    {
        bool FlightExists(string number);
    }
}