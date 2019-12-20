using DAL.EF;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    class UserProfileRepository: IRepository<UserProfile>
    {
        private readonly Context context;

        public UserProfileRepository(Context context)
        {
            this.context = context;
        }

        public void Create(UserProfile item)
        {
            context.Users.Add(item);
        }

        public void Delete(int id)
        {
            var user = context.Users.Find(id);
            context.Users.Remove(user);
        }

        public IEnumerable<UserProfile> Find(Func<UserProfile, bool> predicate)
        {
            return context.Users.Where(predicate);
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return context.Users;
        }

        public UserProfile GetById(int id)
        {
            return context.Users.Find(id);
        }

        public void Update(UserProfile item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
        }
    }
}
