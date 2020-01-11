using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    class CategoryRepository : IRepository<Category>
    {
        private readonly Context context;
        public CategoryRepository(Context context)
        {
            this.context = context;
        }

        public async Task Create(Category item)
        {
           await context.Categories.AddAsync(item);
        }

        public void Delete(int id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await context.Categories.FindAsync(id);
        }

        public void Update(Category item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return context.Categories.Where(predicate);
        }
    }
}
