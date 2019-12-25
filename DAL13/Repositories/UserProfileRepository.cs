using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
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
            context.UserProfiles.Add(item);
        }

        public void Delete(int id)
        {
            var user = context.UserProfiles.Find(id);
            context.UserProfiles.Remove(user);
        }

        public IEnumerable<UserProfile> Find(Func<UserProfile, bool> predicate)
        {
            return context.UserProfiles.Where(predicate);
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return context.UserProfiles;
        }

        public UserProfile GetById(int id)
        {
            return context.UserProfiles.Find(id);
        }

        public void Update(UserProfile item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
        }
    }
}
