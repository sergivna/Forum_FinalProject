using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    class RoleRepository : IRepository<ApplicationRole>
    {
        private readonly Context context;

        public RoleRepository(Context context)
        {
            this.context = context;
        }
        public void Create(ApplicationRole item)
        {
            context.Roles.Add(item);
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

        public IEnumerable<ApplicationRole> GetAll()
        {
            return context.Roles;
        }

        public ApplicationRole GetById(int id)
        {
            return context.Roles.Find(id);
        }

        public void Update(ApplicationRole item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
        }
    }
}
