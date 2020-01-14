using System.Collections.Generic;
using System.Linq;
using WingsOn.Domain.Booking;

namespace WingsOn.Api.Models
{
    public class FlightPassengersDto
    {
        public string FlightNumber { get; set; }
        public List<PersonDto> Passengers { get; set; }

        public static FlightPassengersDto FromFlightPassengers(FlightPassengers flightPassengers)
        {
            return new FlightPassengersDto
            {
                FlightNumber = flightPassengers.FlightNumber,
                Passengers = flightPassengers.Passengers.Select(p => new PersonDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Gender = (GenderType)(int)p.Gender,
                    Email = p.Email,
                    Address = p.Address,
                    DateBirth = p.DateBirth
                }).ToList()
            };
        }
        public FlightPassengers ToFlightPassengers()
        {
            return new FlightPassengers
            {
                FlightNumber = FlightNumber,
                Passengers = Passengers.Select(p => new Person
                {
                    Id = p.Id,
                    Name = p.Name,
                    Gender = (Domain.Booking.GenderType)(int)p.Gender,
                    Email = p.Email,
                    Address = p.Address,
                    DateBirth = p.DateBirth
                }).ToList()
            };
        }
    }
}