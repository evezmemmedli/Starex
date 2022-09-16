
using AutoMapper;
using Microsoft.AspNetCore.Identity;

public class RegisterService : IRegisterService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IJwtTokenService _jwtService;

    public RegisterService(UserManager<AppUser> userManager,IMapper mapper,IJwtTokenService jwtService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _jwtService = jwtService;
    }
    public async Task<AuthenticationResultDto> Register(RegisterPostDto dto)
    {
        AppUser user = await _userManager.FindByEmailAsync(dto.Email);
        if (user != null) throw new Exception();
        user = _mapper.Map<AppUser>(dto);
        IdentityResult createdUser = await _userManager.CreateAsync(user,dto.Password);
        await  _userManager.AddToRoleAsync(user, "User");
        if (!createdUser.Succeeded) throw new Exception(createdUser.Errors.First().Description);
        string token = _jwtService.JwtTokenGenerator(user);
        AuthenticationResultDto authenticationResultDto = _mapper.Map<AuthenticationResultDto>(user);
        authenticationResultDto.JwtToken = token;
        return authenticationResultDto;

        
    }
}

