using System.Collections.Generic;
using System.Linq;
using WingsOn.Domain.Entities;

namespace WingsOn.Domain.Services
{
    public class FlightPassengersService : IFlightPassengersService
    {
        private readonly IRepository<Person> _peopleRepository;
        private readonly IRepository<Booking> _bookingRepository;

        public FlightPassengersService(IRepository<Person> peopleRepository, IRepository<Booking> bookingRepository)
        {
            _peopleRepository = peopleRepository;
            _bookingRepository = bookingRepository;
        }

        public FlightPassengers GetPassengersForFlight(string flightNumber)
        {
            var passengers = _bookingRepository.GetAll().Where(b => b.Flight.Number == flightNumber)
                .SelectMany(f => f.Passengers);
            return new FlightPassengers
            {
                FlightNumber = flightNumber,
                Passengers = passengers.ToList()
            };
        }

        public IEnumerable<Person> GetPassengersByGender(GenderType gender)
        {
            return _peopleRepository.GetAll().Where(p => p.Gender == gender);
        }
    }
}
