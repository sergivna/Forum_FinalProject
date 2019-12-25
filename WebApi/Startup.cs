using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Middleware;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddJwtAuth(services);
            
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(
                  "CorsPolicy",
                  builder => builder.WithOrigins("http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseMiddleware<TokenCookieConvertingMiddleware>();
         

            app.UseCors(options =>
                  options.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddJwtAuth(IServiceCollection services)
        {
            string audience = JwtHelper.Audience;
            string issuer = JwtHelper.Issuer;

            var signingCredentials = JwtHelper.CreateCredentials();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = signingCredentials.Key,

                        ValidIssuer = issuer,
                        ValidateIssuer = true,

                        ValidAudience = audience,
                        ValidateAudience = true,

                        ValidateLifetime = true
                    };
                });
        }
    }
}
