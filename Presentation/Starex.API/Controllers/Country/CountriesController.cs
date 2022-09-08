using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers.Country
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        readonly ICountryService _service;

        public CountriesController(ICountryService service)
        {
            _service = service;
        }
        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] CountryPostDto request)
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
        public IActionResult Update([FromForm] CountryPostDto dto, int id)
        {
            _service.Update(dto, id);
            return NoContent();
        }
    }
}
