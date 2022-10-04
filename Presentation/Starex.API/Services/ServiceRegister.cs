
using Microsoft.OpenApi.Models;

public static class ServiceRegister
{

    public static void Swagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("admin_v1", new OpenApiInfo
            {
                Title = "Employee API",
                Version = "admin_v1",
                Description = "An API to perform Employee operations",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "John Walkner",
                    Email = "John.Walkner@gmail.com",
                    Url = new Uri("https://twitter.com/jwalkner"),
                },
                License = new OpenApiLicense
                {
                    Name = "Employee API LICX",
                    Url = new Uri("https://example.com/license"),
                }
            });

            c.SwaggerDoc("user_v1", new OpenApiInfo
            {
                Title = "Shop User API",
                Version = "user_v1",
                Description = "An API to perform Employee operations",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "John Walkner",
                    Email = "John.Walkner@gmail.com",
                    Url = new Uri("https://twitter.com/jwalkner"),
                },
                License = new OpenApiLicense
                {
                    Name = "Employee API LICX",
                    Url = new Uri("https://example.com/license"),
                }
            });


            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                 new OpenApiSecurityScheme
                 {
                   Reference = new OpenApiReference
                   {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                   }
                  },
                  new string[] { }
                }
     });
        });
    }

}

