using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Apis.Client.Controllers.Declare
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeclaresController : ControllerBase
    {
        private readonly IDeclareService _service;
        public DeclaresController(IDeclareService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create(DeclarePostDto postDto)
        {
            await _service.AddAsync(postDto);
            return Ok();
        }
    }
}
