using System.Collections.Generic;
using WingsOn.Domain.Booking;

namespace WingsOn.Domain
{
    public interface IPeopleRepository : IRepository<Person>
    {
        IEnumerable<Person> GetPassengersByGender(GenderType gender);
    }
}