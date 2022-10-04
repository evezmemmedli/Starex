using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Starex.API.Apis.Client.Controllers;
using Starex.Application.DTOs.Authentication;

namespace Starex.API.Apis.Admin.Controllers.Authentication
{
    public class AuthenticationsController : AdminBaseController
    {
        private readonly IRegisterService _registerService;
        private readonly IPaymentService _paymentService;
        private readonly ILoginService _loginService;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthenticationsController(IRegisterService registerService, RoleManager<IdentityRole> roleManager, ILoginService loginService, IPaymentService paymentService)
        {
            _registerService = registerService;
            _roleManager = roleManager;
            _loginService = loginService;
            _paymentService = paymentService;
        }
        [HttpPost(ApiRoutes.Authentication.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterPostDto dto)
        {
            await _registerService.Register(dto);
            return Ok();
        }
        [HttpGet(ApiRoutes.Authentication.Login)]
        public async Task<IActionResult> Login(string email, string password)
        {
            LoginDto dto = new();
            dto.Email = email;
            dto.Password = password;
            AuthenticationResultDto authenticationResultDto = await _loginService.Login(dto);
            return Ok(authenticationResultDto.JwtToken);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost(ApiRoutes.Authentication.UpdateInformation)]
        public async Task<IActionResult> UpdateUserInformation(UpdatePostDto request)
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
        [Authorize(Roles = "Admin")]
        [HttpGet(ApiRoutes.Authentication.ForgetPassword)]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            return Ok(await _loginService.ForgetPasswordAsync(email));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost(ApiRoutes.Authentication.ResetPassword)]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        {
            await _loginService.ResetPasswordAsync(dto);
            return NoContent();
        }

        [HttpPost(ApiRoutes.Authentication.Verify)]
        public async Task<IActionResult> VerifyEmail(string email, string token)
        {
            await _registerService.VerifyEmail(email, token);
            return Ok();
        }

        //[HttpGet("")]
        //public async Task<IActionResult> GetRole()
        //{
        //    var roleStore = new RoleStore<IdentityRole>(context);
        //    var roleMngr = new RoleManager<IdentityRole>(roleStore);

        //    var roles = roleMngr.Roles.ToList();
        //}

        //[HttpGet("Role")]
        //public async Task<IActionResult> Role()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        //    await _roleManager.CreateAsync(new IdentityRole("User"));
        //    return Ok();
        //}
    }
}
