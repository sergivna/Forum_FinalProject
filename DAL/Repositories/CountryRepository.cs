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
    class CountryRepository : IRepository<Country>
    {
        private readonly Context context;

        public CountryRepository(Context context)
        {
            this.context = context;
        }
        public async Task Create(Country item)
        {
            await context.Countries.AddAsync(item);
        }

        public void Delete(int id)
        {
            var role = context.Countries.Find(id);
            context.Countries.Remove(role);
        }

        public IEnumerable<Country> Find(Func<Country, bool> predicate)
        {
            return context.Countries.Where(predicate);
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await context.Countries.ToListAsync();
        }

        public async Task<Country> GetById(int id)
        {
            return await context.Countries.FindAsync(id);
        }

        public bool Update(Country item)
        {
            try
            {
                context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
