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
    class QuestionRepository : IRepository<Question>
    {
        private readonly Context context;

        public QuestionRepository(Context context)
        {
            this.context = context;
        }
        public async Task Create(Question item)
        {
            await context.Questions.AddAsync(item);
        }

        public void Delete(int id)
        {
            var question = context.Questions.Find(id);
            context.Questions.Remove(question);
        }

        public IEnumerable<Question> Find(Func<Question, bool> predicate)
        {
            return context.Questions.Where(predicate);
        }

        public async Task<IEnumerable<Question>> GetAll()
        {
            return await context.Questions.ToListAsync();
        }

        public async  Task<Question> GetById(int id)
        {
            return await context.Questions.FindAsync(id);
        }

        public bool Update(Question item)
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
