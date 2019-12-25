using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    class QuestionRepository : IRepository<Question>
    {
        private readonly Context context;

        public QuestionRepository(Context context)
        {
            this.context = context;
        }
        public void Create(Question item)
        {
            context.Questions.Add(item);
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

        public IEnumerable<Question> GetAll()
        {
            return context.Questions;
        }

        public Question GetById(int id)
        {
            return context.Questions.Find(id);
        }

        public void Update(Question item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
