using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion.Application.Validators;

namespace ProniaOnion.Application.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation()
             .AddFluentValidationClientsideAdapters()
             .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //???
            services.AddValidatorsFromAssembly(typeof(CreateCategoryDtoValidator).Assembly);

            return services;
        }
    }
}