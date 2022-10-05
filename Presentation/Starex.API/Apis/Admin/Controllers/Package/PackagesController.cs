using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Apis.Admin.Controllers.Package
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        readonly IPackageService _service;

        public PackagesController(IPackageService service)
        {
            _service = service;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpPost("")]
        public async Task<IActionResult> TakeIt(int id)
        {
            await _service.TakeIt(id);
            return NoContent();
        }
    }
}
