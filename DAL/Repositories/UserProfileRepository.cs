using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class UserProfileRepository: IRepository<UserProfile>
    {
        private readonly Context context;

        public UserProfileRepository(Context context)
        {
            this.context = context;
        }

        public async Task Create(UserProfile item)
        {
           await context.UserProfiles.AddAsync(item);
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

        public async Task<IEnumerable<UserProfile>> GetAll()
        {
            return await context.UserProfiles.ToListAsync();
        }

        public async Task<UserProfile> GetById(int id)
        {
            var user = await context.UserProfiles.FindAsync(id);
            return user;
        }

        public void Update(UserProfile item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
        }
    }
}
