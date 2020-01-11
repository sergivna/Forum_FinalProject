using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<UserProfile> UserProfiles { get; }
        IRepository<Category> Categories { get; }
        IRepository<Question> Questions { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Country> Countries { get; }
        IRepository<ApplicationRole> Roles { get; }
        IAdditionalRepository Additional { get; }
        Task SaveChanges();

    }
}
