using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoctAdressesController : ControllerBase
    {

        private readonly IPoctAdressService _poctAdressService;


        public PoctAdressesController(IPoctAdressService poctAdressService)
        {
            _poctAdressService = poctAdressService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Add(PoctAdressPostDto dto)
        {
            await _poctAdressService.AddAsync(dto);
            return StatusCode(201);
        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _poctAdressService.GetAll(false));
        }
    }
}
