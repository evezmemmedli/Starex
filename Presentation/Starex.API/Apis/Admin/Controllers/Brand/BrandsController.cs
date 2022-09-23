using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers.Brand
{
    public class BrandsController : AdminBaseController
    {
        private readonly IBrandService _service;
        public BrandsController(IBrandService service)
        {
            _service = service;
        }
        [HttpPost(ApiRoutes.Brand.Create)]

        //[Authorize("Admin,SuperaDMIN")]
        public async Task<IActionResult> Create([FromForm] BrandPostDto request)
        {
            await _service.AddAsync(request);
            return Created(string.Empty, string.Empty);
        }
        [HttpGet(ApiRoutes.Brand.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet(ApiRoutes.Brand.Get)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(false, id));
        }
        [HttpDelete(ApiRoutes.Brand.Delete)]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return NoContent();
        }
        [HttpPut(ApiRoutes.Brand.Update)]
        public IActionResult Update([FromForm] BrandPostDto dto, int id)
        {
            _service.Update(dto, id);
            return NoContent();
        }
    }
}
