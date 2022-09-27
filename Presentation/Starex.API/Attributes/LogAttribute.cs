using Microsoft.AspNetCore.Mvc.Filters;
using Starex.Application.Interfaces.Services.Logging;

namespace Starex.API.Attributes
{
    public class Log : Attribute, IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var controllerName = context.ActionDescriptor.RouteValues["Controller"]?.ToString();
            var actionName = context.ActionDescriptor.RouteValues["Action"]?.ToString();

            ILogging? logging = (ILogging)context.HttpContext.RequestServices.GetService(typeof(ILogging));

            await logging.LogAction(controllerName, actionName, context.HttpContext);
            await next();

        }
    }
}