using System;

namespace WingsOn.Api.Models
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public DateTime DateBooking { get; set; }
    }
}