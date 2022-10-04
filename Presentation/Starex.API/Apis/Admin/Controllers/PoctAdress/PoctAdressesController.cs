using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PoctAdressesController : ControllerBase
    {
        private readonly IPoctAdressService _poctAdressService;
        public PoctAdressesController(IPoctAdressService poctAdressService)
        {
            _poctAdressService = poctAdressService;
        }

        [HttpPost(ApiRoutes.PoctAdress.Create)]
        public async Task<IActionResult> Add(PoctAdressPostDto dto)
        {
            await _poctAdressService.AddAsync(dto);
            return StatusCode(201);
        }

    }
}
