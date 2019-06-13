using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instructors.WebApi.AutoMapper;
using Instructors.WebApi.Data;
using Instructors.WebApi.Data.Models.Entity;
using Instructors.WebApi.Data.Repository;
using Instructors.WebApi.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Instructors.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string _myAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            string connection = Configuration.GetConnectionString("DefaultConnection");
            // Add a DatabaseContext context as a service to the application.
            services.AddDbContext<DatabaseContext>(options => options.UseSqlite(connection));
            services.AddTransient<IRepository<IEntity>, Repository<IEntity>>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<ICommonMapper, CommonMapper>();
            services.AddCors(options =>
            {
                options.AddPolicy(_myAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
                // Aply migrations. Create database if not exist.
                context.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Global error handler
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });
            }
            
            app.UseCors(_myAllowSpecificOrigins);
            app.UseMvc();
        }
    }
}
