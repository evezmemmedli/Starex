using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Starex.Application.Interfaces.Services.Logging;
using Starex.Persistence.Context;
using Starex.Persistence.Helpers;
using Starex.Persistence.Loggings;
using System.Reflection;
using System.Text;
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
            var jwtSetting = new JwtSetting();
            config.Bind(nameof(jwtSetting), jwtSetting);
            services.AddSingleton(jwtSetting);
            services.AddIdentity<AppUser, IdentityRole>(opt =>
             {
                 opt.User.RequireUniqueEmail = true;
                 opt.Password.RequireDigit = false;
                 opt.Password.RequiredLength = 6;
                 opt.Password.RequireNonAlphanumeric = false;
                 opt.Password.RequireDigit = false;
                 opt.Password.RequireUppercase = false;
                 opt.Lockout.AllowedForNewUsers = true;
             }).AddEntityFrameworkStores<StarexDbContext>().AddDefaultTokenProviders();
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSetting.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
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
            services.AddScoped<IJwtTokenService, JwtService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ILogging, Logging>();
            services.AddScoped<IAppealService, AppealService>();
            services.AddScoped<ICommitmentService, CommitmentService>();
            services.AddScoped<IDeclareService, DeclareService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<IReturnPackageService, ReturnPackageService>();
            services.AddSingleton<FileUrlGenerate>();
        }
    }
}
