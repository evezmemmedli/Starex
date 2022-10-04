using Starex.API.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ApiExplorerSettings(GroupName = "admin_v1")]
[Log]
[ApiController]
public class AdminBaseController : ControllerBase
{
}

