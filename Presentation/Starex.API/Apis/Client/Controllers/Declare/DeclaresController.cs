using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Apis.Client.Controllers.Declare
{

    public class DeclaresController : ClientBaseController
    {
        private readonly IDeclareService _service;
        public DeclaresController(IDeclareService service)
        {
            _service = service;
        }
        [HttpPost(ApiRoutes.DeclareUser.Create)]
        public async Task<IActionResult> Create(DeclarePostDto postDto)
        {
            await _service.AddAsync(postDto);
            return Ok();
        }
        [HttpGet(ApiRoutes.DeclareUser.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }


    }
}
