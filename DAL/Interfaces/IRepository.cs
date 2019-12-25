using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        void Create(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Delete(int id);
        void Update(T item);
        IEnumerable<T> Find(Func<T, bool> predicate);
    }
}
