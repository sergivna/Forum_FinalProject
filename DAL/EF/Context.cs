using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DAL.EF
{
    public class Context: IdentityDbContext<ApplicationUser, ApplicationRole, int,
                IdentityUserClaim<int>, ApplicationUserRole, IdentityUserLogin<int>,
                IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        //public Context(DbContextOptions<Context> options) : base(options)
        //{ }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ConfigurationManager.AppSettings["ForumDatabase"];

            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();



            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("NewDB"));



            // optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["ForumDatabase"]);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.ApplicationUserRoles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationRole>()
              .HasMany(e => e.ApplicationUserRoles)
              .WithOne()
              .HasForeignKey(e => e.RoleId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<ApplicationUserRole>()
            //    .HasOne(e => e.Role)
            //    .WithMany()
            //    .HasForeignKey(e => e.RoleId)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<ApplicationUserRole>()
            // .HasOne(e => e.User)
            // .WithMany()
            // .HasForeignKey(e => e.UserId)
            // .IsRequired()
            // .OnDelete(DeleteBehavior.Cascade);
        }


        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Category> Categories { get; set; }    
        public DbSet<Question> Questions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }

    }
}
