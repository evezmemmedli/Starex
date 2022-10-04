using Microsoft.OpenApi.Models;
using Starex.Persistence.ServiceRegistration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.Swagger();

builder.Services.AddPersistenceRegistration(builder.Configuration);
builder.Services.AddApplicationServiceRegistration();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
    });
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/api/swagger/user_v1/swagger.json", "User API  V1");
        x.SwaggerEndpoint("/api/swagger/admin_v1/swagger.json", "Admin API V1");
        x.RoutePrefix = "api/swagger";
    });
}

app.UseHttpsRedirection();

app.UseCustomExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
