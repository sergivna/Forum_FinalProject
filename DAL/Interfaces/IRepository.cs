using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task Create(T item);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        void Delete(int id);
        bool Update(T item);
        IEnumerable<T> Find(Func<T, bool> predicate);
    }
}
