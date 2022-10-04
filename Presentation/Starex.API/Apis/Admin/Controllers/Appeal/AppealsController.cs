using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Apis.Admin.Controllers.Appeal
{
    [Authorize(Roles = "Admin")]
    public class AppealsController : AdminBaseController
    {
        readonly IAppealService _appealService;
        public AppealsController(IAppealService appealService)
        {
            _appealService = appealService;
        }
        [HttpGet(ApiRoutes.AppealAdmin.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _appealService.GetAll());
        }
    }
}
