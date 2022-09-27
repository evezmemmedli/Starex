using Starex.API.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Log]
[ApiController]
//[Authorize("Admin")]
public class AdminBaseController : ControllerBase
{
}

