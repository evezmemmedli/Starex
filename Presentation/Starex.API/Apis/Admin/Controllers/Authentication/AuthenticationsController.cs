using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers.Register
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly ILoginService _loginService;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthenticationsController(IRegisterService registerService, RoleManager<IdentityRole> roleManager, ILoginService loginService)
        {
            _registerService = registerService;
            _roleManager = roleManager;
            _loginService = loginService;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterPostDto dto)
        {
            AuthenticationResultDto authenticationResultDto = await _registerService.Register(dto);
            return Ok(authenticationResultDto);
        }
        [HttpGet("")]
        public async Task<IActionResult> Login(string email,string password)
        {
            LoginDto dto = new();
            dto.Email = email;
            dto.Password = password;
            AuthenticationResultDto authenticationResultDto = await _loginService.Login(dto);
            return Ok(authenticationResultDto.JwtToken);
        }


        //[HttpGet]
        //public async Task<IActionResult> Role()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        //    await _roleManager.CreateAsync(new IdentityRole("User"));
        //    return Ok();
        //}
    }
}
