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

            //builder.Entity<Comment>()
            //   .HasOne(p => p.Question)
            //   .WithMany(b => b.Comments)
            //   .IsRequired()
            //   .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Comment>()
            //   .HasOne(p => p.User)
            //   .WithMany(b => b.Comments)
            //   .HasForeignKey(k=>k.UserId)
            //   .OnDelete(DeleteBehavior.Cascade);


            //builder.Entity<Question>()
            //    .HasMany(c => c.Comments)
            //    .WithOne(q => q.Question)
            //    .OnDelete(DeleteBehavior.Cascade);

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
