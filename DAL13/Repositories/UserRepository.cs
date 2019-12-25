using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    class UserRepository : IRepository<ApplicationUser>
    {
        private readonly Context context;

        public UserRepository(Context context)
        {
            this.context = context;
        }
        public void Create(ApplicationUser item)
        {
            context.Users.Add(item);
        }

        public void Delete(int id)
        {
            var user = context.Users.Find(id);
            context.Users.Remove(user);
        }

        public IEnumerable<ApplicationUser> Find(Func<ApplicationUser, bool> predicate)
        {
            return context.Users.Where(predicate);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return context.Users;
        }

        public ApplicationUser GetById(int id)
        {
            return context.Users.Find(id);
        }

        public void Update(ApplicationUser item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
