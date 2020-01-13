using System.Collections.Generic;
using WingsOn.Domain.Entities;

namespace WingsOn.Domain.Services
{
    public interface IFlightPassengersService
    {
        FlightPassengers GetPassengersForFlight(string flightNumber);
        IEnumerable<Person> GetPassengersByGender(GenderType gender);
    }
}