using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Starex.Application.DTOs.Authentication;

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
        [HttpPost("")]
        public async Task<IActionResult> Register(RegisterPostDto dto)
        {
            await _registerService.Register(dto);
            return Ok();
        }
        [HttpGet("")]
        public async Task<IActionResult> Login(string email, string password)
        {
            LoginDto dto = new();
            dto.Email = email;
            dto.Password = password;
            AuthenticationResultDto authenticationResultDto = await _loginService.Login(dto);
            return Ok(authenticationResultDto.JwtToken);
        }

        [HttpPost("api/updateUserInformation")]
        public async Task<IActionResult> UpdateUserInformation([FromBody] UpdatePostDto request)
        {
            var response = await _registerService.UpdateUserInformation(request);

            if (response.Status)
            {
                return Ok(response.Message);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
        //[HttpGet("")]
        //public async Task<IActionResult> GetRole()
        //{
        //    var roleStore = new RoleStore<IdentityRole>(context);
        //    var roleMngr = new RoleManager<IdentityRole>(roleStore);

        //    var roles = roleMngr.Roles.ToList();
        //}


        //[HttpGet]
        //public async Task<IActionResult> Role()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        //    await _roleManager.CreateAsync(new IdentityRole("User"));
        //    return Ok();
        //}

        [HttpGet("Email")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
          return Ok(await _loginService.ForgetPasswordAsync(email));
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        {
            await _loginService.ResetPasswordAsync(dto);
            return NoContent();
        }

        [HttpPost("Verify")]
        public  async Task<IActionResult> VerifyEmail(string email,string token)
        {
            await _registerService.VerifyEmail(email, token);
            return Ok();
        }
    }
}
