using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class ServiceRegistrations
{
    public static void AddApplicationServiceRegistration(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
    }
}
