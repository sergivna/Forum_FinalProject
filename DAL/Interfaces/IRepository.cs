using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    interface IRepository<T> where T: class
    {
        void Create(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Delete(int id);
        void Update(T item);
        IEnumerable<T> Find(Func<T, bool> predicate);
    }
}
