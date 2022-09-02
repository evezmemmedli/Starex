using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm]NewsPostDto request)
        {
            await _newsService.AddAsync(request);
            return Created(string.Empty, string.Empty);
        }
    }
}
