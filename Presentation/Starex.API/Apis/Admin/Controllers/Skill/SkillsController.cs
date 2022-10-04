using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers.Skill
{
    [Authorize(Roles = "Admin")]
    public class SkillsController : AdminBaseController
    {
        private readonly ISkillService _service;
        public SkillsController(ISkillService service)
        {
            _service = service;
        }
        [HttpPost(ApiRoutes.Skill.Create)]
        public async Task<IActionResult> Create([FromForm] SkillPostDto request)
        {
            await _service.AddAsync(request);
            return Created(string.Empty, string.Empty);
        }
        [HttpGet(ApiRoutes.Skill.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet(ApiRoutes.Skill.Get)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(false, id));
        }
        [HttpDelete(ApiRoutes.Skill.Delete)]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return NoContent();
        }
        [HttpPut(ApiRoutes.Skill.Update)]
        public IActionResult Update([FromForm] SkillPostDto dto, int id)
        {
            _service.Update(dto, id);
            return NoContent();
        }
    }
}
