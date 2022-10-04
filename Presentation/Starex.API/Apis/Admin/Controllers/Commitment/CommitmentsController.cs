using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Apis.Admin.Controllers.Commitment
{
    [Authorize(Roles = "Admin")]
    public class CommitmentsController : AdminBaseController
    {
        readonly ICommitmentService _commitmentService;

        public CommitmentsController(ICommitmentService commitmentService)
        {
            _commitmentService = commitmentService;
        }
        [HttpGet(ApiRoutes.CommitmentAdmin.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _commitmentService.GetAll());
        }
        [HttpDelete(ApiRoutes.CommitmentAdmin.Delete)]
        public IActionResult Delete(int id)
        {
            _commitmentService.Remove(id);
            return NoContent();
        }
    }
}
