using DAL.EF;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    class CommentRepository : IRepository<Comment>
    {
        private readonly Context context;

        public CommentRepository(Context context)
        {
            this.context = context;
        }
        public void Create(Comment item)
        {
            context.Comments.Add(item);
        }

        public void Delete(int id)
        {
            var comment = context.Comments.Find(id);
            context.Comments.Remove(comment);
        }

        public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
        {
            return context.Comments.Where(predicate);
        }

        public IEnumerable<Comment> GetAll()
        {
            return context.Comments;
        }

        public Comment GetById(int id)
        {
            return context.Comments.Find(id);
        }

        public void Update(Comment item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }
    }
}
