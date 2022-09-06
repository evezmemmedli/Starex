using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers.Advantage
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvantagesController : ControllerBase
    {
        private readonly IAdvantageService _advantageService;

        public AdvantagesController(IAdvantageService advantageService)
        {
            _advantageService = advantageService;
        }
        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] AdvantagePostDto request)
        {
            await _advantageService.AddAsync(request);
            return Created(string.Empty, string.Empty);
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _advantageService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _advantageService.GetByIdAsync(false, id));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _advantageService.Remove(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromForm] AdvantagePostDto dto, int id)
        {
            _advantageService.Update(dto, id);
            return NoContent();
        }
    }
}
