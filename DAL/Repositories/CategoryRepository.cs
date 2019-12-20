using DAL.EF;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfaces
{
    class CategoryRepository : IRepository<Category>
    {
        private readonly Context context;
        public CategoryRepository(Context context)
        {
            this.context = context;
        }

        public void Create(Category item)
        {
            context.Categories.Add(item);
        }

        public void Delete(int id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return context.Categories;
        }

        public Category GetById(int id)
        {
            return context.Categories.Find(id);
        }

        public void Update(Category item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return context.Categories.Where(predicate);
        }
    }
}
