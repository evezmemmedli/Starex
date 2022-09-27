using Microsoft.AspNetCore.Http;

namespace Starex.Application.Interfaces.Services.Logging;
public interface ILogging
{
    Task LogAction(string controllerName, string actionName, HttpContext context);
    Task LogError(Exception ex, HttpContext context);    
}    