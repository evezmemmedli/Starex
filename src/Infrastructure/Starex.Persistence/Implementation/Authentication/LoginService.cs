
using AutoMapper;
using Microsoft.AspNetCore.Identity;

public class LoginService : ILoginService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IJwtTokenService _jwtService;

    public LoginService(UserManager<AppUser> userManager, IMapper mapper, IJwtTokenService jwtService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _jwtService = jwtService;
    }
    public async Task<AuthenticationResultDto> Login(LoginDto dto)
    {
       AppUser user = await _userManager.FindByEmailAsync(dto.Email);
        if(user is null) throw new ItemNotFoundException("Password or Username is incorrect");
        var result = await _userManager.CheckPasswordAsync(user,dto.Password);

 
        if (!result) throw new ItemNotFoundException("Password or Username is incorrect");

        string token =  _jwtService.JwtTokenGenerator(user);
        var authResult = _mapper.Map<AuthenticationResultDto>(user);
        authResult.JwtToken = token;
        return  authResult;
    }
}

