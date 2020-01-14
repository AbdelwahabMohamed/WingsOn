﻿using System;
using WingsOn.Domain.Booking;

namespace WingsOn.Api.Models
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public GenderType Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public static PersonDto FromPerson(Person person)
        {
            return new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                DateBirth =  person.DateBirth,
                Gender =  (GenderType)(int)person.Gender,
                Address = person.Address,
                Email = person.Email
            };
        }
        public  Person ToPerson()
        {
            return new Person
            {
                Id = Id,
                Name = Name,
                DateBirth = DateBirth,
                Gender = (Domain.Booking.GenderType) Gender,
                Address = Address,
                Email = Email
            };
        }
    }
}