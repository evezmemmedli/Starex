using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers.Advantage
{
    [Authorize(Roles = "Admin")]
    public class AdvantagesController : AdminBaseController
    {
        private readonly IAdvantageService _advantageService;
        public AdvantagesController(IAdvantageService advantageService)
        {
            _advantageService = advantageService;
        }
        [HttpPost(ApiRoutes.Advantage.Create)]
        public async Task<IActionResult> Create([FromForm] AdvantagePostDto request)
        {
            await _advantageService.AddAsync(request);
            return Created(string.Empty, string.Empty);
        }
        [HttpGet(ApiRoutes.Advantage.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _advantageService.GetAll());
        }
        [HttpGet(ApiRoutes.Advantage.Get)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _advantageService.GetByIdAsync(false, id));
        }
        [HttpDelete(ApiRoutes.Advantage.Delete)]
        public IActionResult Delete(int id)
        {
            _advantageService.Remove(id);
            return NoContent();
        }
        [HttpPut(ApiRoutes.Advantage.Update)]
        public IActionResult Update([FromForm] AdvantagePostDto dto, int id)
        {
            _advantageService.Update(dto, id);
            return NoContent();
        }
    }
}
