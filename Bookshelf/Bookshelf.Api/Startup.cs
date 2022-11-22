using FluentValidation;
using FluentValidation.AspNetCore;
using Bookshelf.Api.BindingModels;
using Bookshelf.Api.Middlewares;
using Bookshelf.Api.Validation;
using Bookshelf.Data.Sql;
using Bookshelf.Data.Sql.Book;
using Bookshelf.Data.SQL.Migrations;
using Bookshelf.Data.Sql.User;
using Bookshelf.Data.Sql.User;
using Bookshelf.IData.Book;
using Bookshelf.IData.User;
using Bookshelf.IServices.Book;
using Bookshelf.IServices.User;
using Bookshelf.Services.Book;
using Bookshelf.Services.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using EditBookValidator = Bookshelf.Api.Validation.EditBookValidator;
using EditUserValidator = Bookshelf.Api.Validation.EditUserValidator;

namespace Bookshelf.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // method to add services and cors support to the app container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookshelfDbContext>(options => options
                .UseMySQL(Configuration.GetConnectionString("BookshelfDbContext")));
            services.AddTransient<DatabaseSeed>();
            services.AddControllers()
                .AddNewtonsoftJson(options => {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddFluentValidation();
            services.AddTransient<IValidator<EditUser>, EditUserValidator>();
            services.AddTransient<IValidator<CreateUser>, CreateUserValidator>();
            services.AddTransient<IValidator<EditBook>, EditBookValidator>();
            services.AddTransient<IValidator<CreateBook>, CreateBookValidator>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
            
            services.AddApiVersioning( o =>
            {
                o.ReportApiVersions = true;
                o.UseApiBehavior = false;
            });
            services.AddCors();
        }

        // method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod());
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<BookshelfDbContext>();
                var databaseSeed = serviceScope.ServiceProvider.GetRequiredService<DatabaseSeed>();
                
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                databaseSeed.Seed();
            }
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


