using AutoMapper;
using Microsoft.AspNetCore.Identity;
public class LoginService : ILoginService
{
    readonly UserManager<AppUser> _userManager;
    readonly IMapper _mapper;
    readonly IJwtTokenService _jwtService;
    readonly IEmailService _emailService;
    public LoginService(UserManager<AppUser> userManager, IMapper mapper, IJwtTokenService jwtService, IEmailService emailService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _jwtService = jwtService;
        _emailService = emailService;
    }
    public async Task<AuthenticationResultDto> Login(LoginDto dto)
    {
        AppUser user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is null) throw new ItemNotFoundException("Password or Username is incorrect");
        var result = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (!result) throw new ItemNotFoundException("Password or Username is incorrect");
        if (!user.EmailConfirmed)
            throw new ItemNotFoundException("Please verify your email");
        //var roles=await _userManager.GetRolesAsync(user);
        //if (!roles.Any(x=>x.Contains("Admin"))) throw new ItemNotFoundException("Password or Username is incorrect");
        string token = _jwtService.JwtTokenGenerator(user);
        var authResult = _mapper.Map<AuthenticationResultDto>(user);
        authResult.JwtToken = token;
        return authResult;
    }
    public async Task<string> ForgetPasswordAsync(string email)
    {
        AppUser user = await _userManager.FindByEmailAsync(email);
        if (user is null)
            throw new ItemNotFoundException("User does not found");
        if (!user.EmailConfirmed)
            throw new ItemNotFoundException("Please verify yout email");
        string token = await _userManager.GeneratePasswordResetTokenAsync(user);
        await _emailService.SendEmail(email, token, "Reset Password");
        return token;
    }
    public async Task ResetPasswordAsync(ResetPasswordDto dto)
    {
        AppUser user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is null)
            throw new ItemNotFoundException("User not found");
        await _userManager.ResetPasswordAsync(user, dto.Token, dto.Password);
    }
}

