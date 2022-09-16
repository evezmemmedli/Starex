    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers.AboutSkill
{
   
    public class AboutSkillsController : BaseController
    {
        private readonly IAboutSkillService _service;
        public AboutSkillsController(IAboutSkillService service)
        {
            _service = service;
        }
        [HttpPost(ApiRoutes.AboutSkill.Create)]
        public async Task<IActionResult> Create([FromForm] AboutSkillPostDto request)
        {
            await _service.AddAsync(request);
            return Created(string.Empty, string.Empty);
        }
        [HttpGet(ApiRoutes.AboutSkill.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet(ApiRoutes.AboutSkill.Get)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(false, id));
        }
        [HttpDelete(ApiRoutes.AboutSkill.Delete)]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return NoContent();
        }
        [HttpPut(ApiRoutes.AboutSkill.Update)]
        public IActionResult Update([FromForm] AboutSkillPostDto dto, int id)
        {
            _service.Update(dto, id);
            return NoContent();
        }
    }
}
