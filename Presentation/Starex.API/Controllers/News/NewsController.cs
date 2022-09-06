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
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _newsService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _newsService.GetByIdAsync(false,id));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _newsService.Remove(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromForm]NewsPostDto dto, int id)
        {
            _newsService.Update(dto, id);
            return NoContent();
        }
    }
}
