using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastructure
{
    public static class Exstentions
    {
        public static IServiceCollection SetUpAppDependencies(this IServiceCollection services,
           string connectionString)
        {
            services.AddDbContext<Context>(x => x.UseSqlServer(connectionString, b => b.MigrationsAssembly("WebAPI")));
            return services;
        }

        public static IServiceCollection SetUpRoles(this IServiceCollection services)
        {
            IdentityBuilder builder = services.AddIdentityCore<ApplicationUser>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(ApplicationRole), builder.Services);
            builder.AddEntityFrameworkStores<Context>();
            builder.AddRoleValidator<RoleValidator<ApplicationRole>>();
            builder.AddRoleManager<RoleManager<ApplicationRole>>();
            builder.AddSignInManager<SignInManager<ApplicationUser>>();

            return services;
        }

        public static IServiceCollection SetUpScopes(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
    //        services.AddScoped<IAuthService, AuthService>();
            return services;
        }

        public static int CalculateAge(DateTime theDateTime)
        {
            var age = System.DateTime.Now.Year - theDateTime.Year;
            if (theDateTime.AddYears(age) > DateTime.Today)
            {
                age--;
            }

            return age;
        }

    }
}
