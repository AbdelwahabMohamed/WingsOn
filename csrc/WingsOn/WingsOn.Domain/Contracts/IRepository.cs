using System.Collections.Generic;

namespace WingsOn.Domain.Contracts
{
    public interface IRepository<T> where T : DomainObject
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        T Save(T element);
    }
}