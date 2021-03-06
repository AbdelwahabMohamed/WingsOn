﻿using System.Collections.Generic;
using WingsOn.Domain.Booking;

namespace WingsOn.Domain.Contracts
{
    public interface IBookingService
    {
        IEnumerable<Person> GetPassengersForFlight(string flightNumber);
        Booking.Booking CreateBookingForNewPassengerForExistingFlight(string flightNumber, Person passenger);
    }

}