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
    class CommentRepository : IRepository<Comment>
    {
        private readonly Context context;

        public CommentRepository(Context context)
        {
            this.context = context;
        }
        public async Task Create(Comment item)
        {
            await  context.Comments.AddAsync(item);
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

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await context.Comments.ToListAsync();
        }

        public async Task<Comment> GetById(int id)
        {
            return await context.Comments.FindAsync(id);
        }

        public void Update(Comment item)
        {
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }
    }
}
