using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Apis.Client.Controllers.Commitment
{
    [Authorize]
    public class CommitmentsController : ClientBaseController
    {
        readonly ICommitmentService _commitmentService;

        public CommitmentsController(ICommitmentService commitmentService)
        {
            _commitmentService = commitmentService;
        }
        [HttpPost(ApiRoutes.CommitmentUser.Create)]
        public async Task<IActionResult> Create(CommitmentPostDto postDto)
        {
            await _commitmentService.AddAsync(postDto);
            return Ok();
        }
        [HttpGet(ApiRoutes.CommitmentUser.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _commitmentService.GetAll());
        }
    }
}
