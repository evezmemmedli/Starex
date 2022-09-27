using Microsoft.AspNetCore.Http;
namespace Starex.Persistence.Helpers;
public class FileUrlGenerate
{
    private static string baseUrl;
    public FileUrlGenerate(IHttpContextAccessor httpContextAccessor)
    {
        baseUrl =
            $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host.ToUriComponent()}";
    }
    public string PhotoUrlGenerate(string photoName)
        => baseUrl + "/" + ApiRoutes.File.GetFileByName.Replace("{fileName}", photoName);
}

