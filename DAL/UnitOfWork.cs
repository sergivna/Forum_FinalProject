using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Threading.Tasks;

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
        private AdditionalRepository additionalRepository;
        private CountryRepository countryRepository;
        private RoleRepository roleRepository;

        public UnitOfWork(Context context)
        {
            this.context = context;
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

        public IAdditionalRepository Additional
        {
            get
            {
                if (additionalRepository == null)
                    return new AdditionalRepository(context);
                return additionalRepository;
            }
        }   
        public IRepository<Country> Countries
        {
            get
            {
                if (countryRepository == null)
                    return new CountryRepository(context);
                return countryRepository;
            }
        }

        public IRepository<ApplicationRole> Roles
        {
            get
            {
                if (roleRepository == null)
                    return new RoleRepository(context);
                return roleRepository;
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

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
