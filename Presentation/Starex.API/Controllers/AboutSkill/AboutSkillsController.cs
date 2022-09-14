using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers.AboutSkill
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutSkillsController : ControllerBase
    {
        private readonly IAboutSkillService _service;

        public AboutSkillsController(IAboutSkillService service)
        {
            _service = service;
        }
        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] AboutSkillPostDto request)
        {
            await _service.AddAsync(request);
            return Created(string.Empty, string.Empty);
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(false, id));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromForm] AboutSkillPostDto dto, int id)
        {
            _service.Update(dto, id);
            return NoContent();
        }
    }
}
