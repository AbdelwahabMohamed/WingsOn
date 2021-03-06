﻿using System.Collections.Generic;
using WingsOn.Domain.Booking;

namespace WingsOn.Domain.Contracts
{
    public interface IPeopleRepository : IRepository<Person>
    {
        IEnumerable<Person> GetPassengersByGender(GenderType gender);
        Person UpdateEmail(int id, string email);
    }
}