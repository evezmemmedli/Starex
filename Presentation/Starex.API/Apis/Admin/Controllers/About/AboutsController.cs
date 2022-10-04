using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers.About
{
    [Authorize(Roles = "Admin")]
    public class AboutsController : AdminBaseController
    {
        private readonly IAboutService _aboutService;
        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpPost(ApiRoutes.About.Create)]
        public async Task<IActionResult> Create([FromForm] AboutPostDto request)
        {
            await _aboutService.AddAsync(request);
            return Created(string.Empty, string.Empty);
        }
        [HttpGet(ApiRoutes.About.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _aboutService.GetAll());
        }
        [HttpGet(ApiRoutes.About.Get)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _aboutService.GetByIdAsync(false, id));
        }
        [HttpDelete(ApiRoutes.About.Delete)]
        public IActionResult Delete(int id)
        {
            _aboutService.Remove(id);
            return NoContent();
        }
        [HttpPut(ApiRoutes.About.Update)]
        public IActionResult Update([FromForm] AboutPostDto dto, int id)
        {
            _aboutService.Update(dto, id);
            return NoContent();
        }
    }
}
