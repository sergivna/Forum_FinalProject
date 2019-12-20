using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<UserProfile> UserProfiles { get; }
        IRepository<Category> Categories { get; }
        IRepository<Question> Questions { get; }
        IRepository<Comment> Comments { get; }
        void SaveChanges();

    }
}
