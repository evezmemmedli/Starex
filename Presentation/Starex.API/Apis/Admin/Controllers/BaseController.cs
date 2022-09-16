using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers
{
    [ApiController]
    [Authorize()]
    public class BaseController : ControllerBase
    {
    }
}
