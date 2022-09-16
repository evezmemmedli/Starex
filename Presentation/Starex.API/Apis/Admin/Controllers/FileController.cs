using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Starex.API.Controllers
{
    public class FileController : BaseController
    {
        private readonly string _filePath = Directory.GetCurrentDirectory() + "/wwwroot/Images";
        [HttpGet(ApiRoutes.File.GetFileByName)]
        public async Task<IActionResult> GetFileByName(string fileName)
        {
            var photoFullPath = Path.Combine(_filePath, fileName);
            var str = System.IO.File.OpenRead(photoFullPath);
            return File(str, Image.Jpeg);
        }
    }
}
