using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers.Setting
{
    [Authorize(Roles = "Admin")]
    public class SettingsController : AdminBaseController
    {
        private readonly ISettingService _service;
        public SettingsController(ISettingService service)
        {
           _service = service;
        }
        [HttpPost(ApiRoutes.Setting.Create)]
        public async Task<IActionResult> Create([FromForm] SettingPostDto request)
        {
            await _service.AddAsync(request);
            return Created(string.Empty, string.Empty);
        }
        [HttpGet(ApiRoutes.Setting.GetAll)]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _service.GetAll());
        }
        [HttpGet(ApiRoutes.Setting.Get)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(false, id));
        }
        [HttpDelete(ApiRoutes.Setting.Delete)]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return NoContent();
        }
        [HttpPut(ApiRoutes.Setting.Update)]
        public IActionResult Update([FromForm] SettingPostDto dto, int id)
        {
            _service.Update(dto, id);
            return NoContent();
        }
    }
}
