using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers.FaqQuestion
{
    public class FaqQuestionsController : ControllerBase
    {
        private readonly IFaqQuestionService _service;
        public FaqQuestionsController(IFaqQuestionService service)
        {
            _service = service;
        }
        [HttpPost(ApiRoutes.FaqQuestion.Create)]
        public async Task<IActionResult> Create([FromForm] FaqQuestionPostDto request)
        {
            await _service.AddAsync(request);
            return Created(string.Empty, string.Empty);
        }
        [HttpGet(ApiRoutes.FaqQuestion.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet(ApiRoutes.FaqQuestion.Get)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(false, id));
        }
        [HttpDelete(ApiRoutes.FaqQuestion.Delete)]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return NoContent();
        }
        [HttpPut(ApiRoutes.FaqQuestion.Update)]
        public IActionResult Update([FromForm] FaqQuestionPostDto dto, int id)
        {
            _service.Update(dto, id);
            return NoContent();
        }
    }
}
