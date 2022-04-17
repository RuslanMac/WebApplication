using Database;
using Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Service;
using Service.Dtos;
using Service.Mapper;
using Service.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySolution
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
            services.AddControllers()
              .AddFluentValidation(s =>
              {
                  s.RegisterValidatorsFromAssemblyContaining<Startup>();
              });

            ConfigureDbConnection(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
            // register services fot mapper
            services.AddSingleton<IWebProjectMapper, WebProjectMapper>();
            // register services for validators
            services.AddScoped<IDtoValidator, DtoValidator>();
            services.AddTransient<IValidator<TaskDto>, TaskDtoValidator>();
            services.AddScoped<IValidator<ProjectDto>, ProjectDtoValidator>();
            services.AddScoped<IValidator<ProjectCreateDto>, ProjectCreateValidator>();

            // services registration
            services.AddTransient<ProjectService>();
            services.AddTransient<TaskService>();
            services.AddScoped<IDbRepository<ProjectModel>, DbRepository<ProjectModel>>();
            services.AddScoped<IDbRepository<TaskModel>, DbRepository<TaskModel>>();


        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureDbConnection(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
               options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

        }
    }
}
