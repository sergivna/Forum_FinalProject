using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DAL.EF
{
    public class Context: DbContext
    {
        //public Context(DbContextOptions<Context> options) : base(options)
        //{ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ConfigurationManager.AppSettings["ForumDatabase"]

            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ForumDatabase"));


           // optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["ForumDatabase"]);
        }

        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Category> Categories { get; set; }    
        public DbSet<Question> Questions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }

    }
}
