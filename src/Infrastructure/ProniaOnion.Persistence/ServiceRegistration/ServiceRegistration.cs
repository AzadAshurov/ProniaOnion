﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Abstractions.Services;
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
            services
                .AddDbContext<AppDbContext>(opt =>
                    opt.UseSqlServer(configuration.GetConnectionString("Home"))
                );

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            return services;
        }
    }
}
