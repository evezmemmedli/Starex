using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Starex.API.Apis.Client.Controllers.Appeal
{
    [Authorize]
    public class AppealsController : ClientBaseController
    {
        readonly IAppealService _appealService;
        public AppealsController(IAppealService appealService)
        {
            _appealService = appealService;
        }
        [HttpPost(ApiRoutes.AppealUser.Create)]
        public async Task<IActionResult> Create(AppealPostDto postDto)
        {
            await _appealService.AddAsync(postDto);
            return Ok(postDto);
        }
        [HttpGet(ApiRoutes.AppealUser.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _appealService.GetAll());
        }

    }
}
