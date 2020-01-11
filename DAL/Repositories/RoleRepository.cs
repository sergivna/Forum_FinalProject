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
    class RoleRepository : IRepository<ApplicationRole>
    {
        private readonly Context context;

        public RoleRepository(Context context)
        {
            this.context = context;
        }
        public async Task Create(ApplicationRole item)
        {
            await context.Roles.AddAsync(item);
        }

        public void Delete(int id)
        {
            var role = context.Roles.Find(id);
            context.Roles.Remove(role);
        }

        public IEnumerable<ApplicationRole> Find(Func<ApplicationRole, bool> predicate)
        {
            return context.Roles.Where(predicate);
        }

        public async Task<IEnumerable<ApplicationRole>> GetAll()
        {
            return await context.Roles.ToListAsync();
        }

        public async Task<ApplicationRole> GetById(int id)
        {
            return await context.Roles.FindAsync(id);
        }

        public void Update(ApplicationRole item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
        }
    }
}
