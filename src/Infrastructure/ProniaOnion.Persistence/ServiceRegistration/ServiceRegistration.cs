using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Domain.Entities.Identity;
using ProniaOnion.Persistence.DAL;
using ProniaOnion.Persistence.Implementations.Repositories;
using ProniaOnion.Persistence.Implementations.Repositories.Generic;
using ProniaOnion.Persistence.Implementations.Services;

namespace ProniaOnion.Persistence.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connection;
            switch (1) {
                case 1:
                    connection = "HomeLaptop";
                    break;
                 case 2:
                 connection = "Home";
                    break;
                    case 3:
                    connection = "Univer";
                    break;
            }

            services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(
        configuration.GetConnectionString($"{connection}"),
        m => m.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)
    )
);

            //services
            //    .AddDbContext<AppDbContext>(opt =>
            //        opt.UseSqlServer(configuration.GetConnectionString("HomeLaptop"))
            //    );

            //services
            //    .AddDbContext<AppDbContext>(opt =>
            //        opt.UseSqlServer(configuration.GetConnectionString("Home"))
            //    );

            //services
            //    .AddDbContext<AppDbContext>(opt =>
            //        opt.UseSqlServer(configuration.GetConnectionString("Univer"))
            //    );

            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = false;

                opt.User.RequireUniqueEmail = true;

                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                opt.Lockout.MaxFailedAccessAttempts = 3;
            })
.AddDefaultTokenProviders()
.AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IColorService, ColorService>();

            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagService, TagService>();

            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<ISizeService, SizeService>();

            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogService, BlogService>();

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();

            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            return services;
        }
    }
}
