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
    class UserRepository : IRepository<ApplicationUser>
    {
        private readonly Context context;

        public UserRepository(Context context)
        {
            this.context = context;
        }
        public async Task Create(ApplicationUser item)
        {
            await  context.Users.AddAsync(item);
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

        public async Task<IEnumerable<ApplicationUser>> GetAll()
        {
            return  await context.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetById(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public void Update(ApplicationUser item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
