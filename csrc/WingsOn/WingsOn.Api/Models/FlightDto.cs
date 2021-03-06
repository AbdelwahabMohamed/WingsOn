﻿using System;

namespace WingsOn.Api.Models
{
    public class FlightDto
    {
        public string Number { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ArrivalDate { get; set; }

        public decimal Price { get; set; }
    }
}