using System.Collections.Generic;

namespace WingsOn.Domain.Entities
{
    public class FlightPassengers
    {
        public string FlightNumber { get; set; }
        public List<Person> Passengers { get; set; }
    }
}