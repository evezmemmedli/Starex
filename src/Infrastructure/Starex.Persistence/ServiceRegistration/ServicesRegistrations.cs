using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Starex.Application.Repositories;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Starex.Persistence.ServiceRegistration
{
    public static class ServicesRegistrations
    {
        public static void AddPersistenceRegistration(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<StarexDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("default"));
            });
            services.AddValidatorsFromAssemblyContaining<PoctAdressPostDto>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IPoctAdressService, PoctAdressService>();
            services.AddScoped<IDeliveryPointService, DeliveryPointService>();
            services.AddScoped<INewsService, NewsService>();


        }

    }
}
