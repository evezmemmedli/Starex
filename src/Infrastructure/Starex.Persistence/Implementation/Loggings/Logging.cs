using Microsoft.AspNetCore.Http;
using Starex.Application.Interfaces.Services.Logging;
using Starex.Domain.Entities.Logging;
namespace Starex.Persistence.Loggings;
public class Logging : ILogging
{
    readonly IUnitOfWork _unitOfWork;
    public Logging(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task LogAction(string controllerName, string actionName, HttpContext context)
    {
        ActionLog actionLog = new()
        {
            ControllerName = controllerName,
            ActionName = actionName,
            Method = context.Request.Method,
            Path = context.Request.Path,
            IpAddress = context.Connection.RemoteIpAddress?.ToString() ?? string.Empty,
            CreatedDate = DateTime.UtcNow
        };
        await _unitOfWork.ActionLogWriteRepository.AddAsync(actionLog);
        await _unitOfWork.ActionLogWriteRepository.CommitAsync();
    }
    public async Task LogError(Exception ex, HttpContext context)
    {
        var url =
            $"{context.Request.Scheme}://{context.Request.Host.ToUriComponent()}";
        ErrorLog error = new()
        {
            Exception = ex.StackTrace,
            ExceptionCode = GenerateExceptionCode(),
            Message = ex.Message,
            CreatedDate = DateTime.UtcNow,
            ErrorPage = url,
            IpAddress = context.Connection.RemoteIpAddress?.ToString() ?? string.Empty
        };
        await _unitOfWork.ErrorLogWriteRepository.AddAsync(error);
        await _unitOfWork.ErrorLogWriteRepository.CommitAsync();
    }

    private static string GenerateExceptionCode()
    {
        try
        {
            Random a = new Random();

            var exceptionCode = "Starex___" + DateTime.Now.ToString("ddMMyyyyhhmmss") + a.Next(1000, 10000);
            return exceptionCode;
        }
        catch (Exception)
        {
            return "***************";
        }
    }
}