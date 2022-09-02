using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistrations
{
    public static void AddApplicationServiceRegistration(this IServiceCollection services)
    {
        services.AddAutoMapper(opt =>
        {
            opt.AddProfile(new GeneralMap());
        });
    }
}
