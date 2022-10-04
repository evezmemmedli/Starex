using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers.Country
{
    [Authorize(Roles = "Admin")]
    public class CountriesController : AdminBaseController
    {
        readonly ICountryService _service;
        public CountriesController(ICountryService service)
        {
            _service = service;
        }
        [HttpPost(ApiRoutes.Country.Create)]
        public async Task<IActionResult> Create([FromForm] CountryPostDto request)
        {
            await _service.AddAsync(request);
            return Created(string.Empty, string.Empty);
        }
        [HttpGet(ApiRoutes.Country.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet(ApiRoutes.Country.Get)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(false, id));
        }
        [HttpDelete(ApiRoutes.Country.Delete)]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return NoContent();
        }
        [HttpPut(ApiRoutes.Country.Update)]
        public IActionResult Update([FromForm] CountryPostDto dto, int id)
        {
            _service.Update(dto, id);
            return NoContent();
        }
    }
}
