using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private readonly Context context;

        private UserProfileRepository userProfileRepository;
        private CategoryRepository categoryRepository;
        private QuestionRepository questionRepository;
        private CommentRepository commentRepository;

        public UnitOfWork()
        {
            context = new Context();
        }
        public IRepository<UserProfile> UserProfiles
        { 
            get
            {
                if (userProfileRepository == null)
                    return new UserProfileRepository(context);
                return userProfileRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    return new CategoryRepository(context);
                return categoryRepository;
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                if (questionRepository == null)
                    return new QuestionRepository(context);
                return questionRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    return new CommentRepository(context);
                return commentRepository;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            if (disposing)
            {
                context.Dispose();
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
