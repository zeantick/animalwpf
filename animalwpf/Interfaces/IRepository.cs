using System;
using System.Collections.Generic;

namespace animalwpf.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
        IEnumerable<T> GetAll();
        T Find(Func<T, bool> predicate);
    }
}
