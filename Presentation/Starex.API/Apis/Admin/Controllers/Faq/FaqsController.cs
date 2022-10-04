using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers.Faq
{
    [Authorize(Roles = "Admin")]
    public class FaqsController : AdminBaseController
    {
        private readonly IFaqService _service;
        public FaqsController(IFaqService service)
        {
            _service = service;
        }
        [HttpPost(ApiRoutes.Faq.Create)]
        public async Task<IActionResult> Create([FromForm] FaqPostDto request)
        {
            await _service.AddAsync(request);
            return Created(string.Empty, string.Empty);
        }
        [HttpGet(ApiRoutes.Faq.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet(ApiRoutes.Faq.Get)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(false, id));
        }
        [HttpDelete(ApiRoutes.Faq.Delete)]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return NoContent();
        }
        [HttpPut(ApiRoutes.Faq.Update)]
        public IActionResult Update([FromForm] FaqPostDto dto, int id)
        {
            _service.Update(dto, id);
            return NoContent();
        }
    }
}

