using System.Collections.Generic;
using WingsOn.Domain.Entities;

namespace WingsOn.Domain
{
    public interface IRepository<T> where T : DomainObject
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Save(T element);
    }
}