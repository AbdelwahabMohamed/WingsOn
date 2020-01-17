using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using WingsOn.Domain.Contracts;

namespace WingsOn.Domain.Booking
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IPeopleRepository _peopleRepository;
        private readonly IRepository<Flight> _flightRepository;

        public BookingService(IRepository<Booking> bookingRepository, IPeopleRepository peopleRepository, IRepository<Flight> flightRepository)
        {
            _bookingRepository = bookingRepository;
            _peopleRepository = peopleRepository;
            _flightRepository = flightRepository;
        }

        public IEnumerable<Person> GetPassengersForFlight(string flightNumber)
        {

            var passengers = _bookingRepository.GetAll().Where(b => b.Flight.Number == flightNumber)
                .SelectMany(f => f.Passengers);
            return passengers;
        }

        public bool FlightExists(string flightNumber)
        {
            return _flightRepository.GetAll().Any(f => f.Number == flightNumber);
        }

        public Booking CreateBookingForNewPassengerForExistingFlight(string flightNumber, Person passenger)
        {
            var flight = _flightRepository.GetAll().First(f => f.Number == flightNumber);
            var savedPassenger = _peopleRepository.Save(passenger);
            var booking = new Booking
            {
                DateBooking = DateTime.Now,
                Flight = flight,
                Number = Guid.NewGuid().ToString(),
                Customer = savedPassenger
            };
            _bookingRepository.Save(booking);
            return booking;
        }
    }
}