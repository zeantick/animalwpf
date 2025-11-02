using System;
using System.Collections.Generic;
using System.Linq;
using animalwpf.Interfaces;

namespace animalwpf.Models
{
    public class Repository<T> : IRepository<T>
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return items;
        }

        public T Find(Func<T, bool> predicate)
        {

            return items.FirstOrDefault(predicate);
        }
    }
}
