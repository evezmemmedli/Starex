using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Starex.Application.Repositories;
using Starex.Persistence.Context;
using Starex.Persistence.Helpers;
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
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IAdvantageService, AdvantageService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IFaqService, FaqService>();
            services.AddScoped<IFaqQuestionService, FaqQuestionService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IAboutSkillService, AboutSkillService>();
            services.AddScoped<ISkillService, SkillService>();

            services.AddSingleton<FileUrlGenerate>();
        }

    }
}
