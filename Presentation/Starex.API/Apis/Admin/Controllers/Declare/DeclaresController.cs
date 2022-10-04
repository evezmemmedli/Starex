using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Apis.Admin.Controllers.Declare
{
    [Authorize(Roles = "Admin")]
    public class DeclaresController : AdminBaseController
    {
        readonly IDeclareService _service;
        public DeclaresController(IDeclareService declareService)
        {
            _service = declareService;
        }
        [HttpGet(ApiRoutes.DeclareAdmin.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpDelete(ApiRoutes.DeclareAdmin.Delete)]
        public IActionResult Remove(int id)
        {
            _service.Remove(id);
            return NoContent();
        }
        [HttpGet(ApiRoutes.DeclareAdmin.Get)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetById(id));
        }

    }
}
