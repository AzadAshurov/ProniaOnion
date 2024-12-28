﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion.Persistence.DAL;

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

            return services;
        }
    }
}