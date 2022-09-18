
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Starex.Application.DTOs.Authentication;

public class RegisterService : IRegisterService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IJwtTokenService _jwtService;
    private readonly IEmailService _emailService;

    public RegisterService(UserManager<AppUser> userManager, IMapper mapper, IJwtTokenService jwtService, IEmailService emailService = null)
    {
        _userManager = userManager;
        _mapper = mapper;
        _jwtService = jwtService;
        _emailService = emailService;
    }
    public async Task Register(RegisterPostDto dto)
    {
        AppUser user = await _userManager.FindByEmailAsync(dto.Email);
        if (user != null) throw new Exception();
        user = _mapper.Map<AppUser>(dto);
        IdentityResult createdUser = await _userManager.CreateAsync(user, dto.Password);
        await _userManager.AddToRoleAsync(user, "User");
        if (!createdUser.Succeeded) throw new Exception(createdUser.Errors.First().Description);
        string token=await _userManager.GenerateEmailConfirmationTokenAsync(user);
       await _emailService.SendEmail(dto.Email, token, "Verify Email");       
    }


    public async Task<UpdateUserResponseDto> UpdateUserInformation(UpdatePostDto requestDto)
    {
        var response = new UpdateUserResponseDto();
        var currentUser = await _userManager.FindByEmailAsync(requestDto.Email);

        if (currentUser == null)
        {
            response.Message = "Bu email ilə istifadəçi mövcud deyil";
            return response;
        }

        var passwordIsCorrect = await _userManager.CheckPasswordAsync(currentUser, requestDto.Password);
        if (!passwordIsCorrect)
        {
            response.Message = "Istifadəçinin şifrəsi düzgün deyil.";
            return response;
        }
        await _userManager.ChangePasswordAsync(currentUser, requestDto.Password, requestDto.NewConfirmPassword);

        currentUser.Name = requestDto.Name;
        currentUser.Email = requestDto.Email;
        currentUser.PhoneNumber = requestDto.PhoneNumber;
        currentUser.Surname = requestDto.Surname;
        currentUser.Adress = requestDto.Adress;
        currentUser.DeliveryPointId = requestDto.DeliveryPointId;
        currentUser.PoctAdressId = requestDto.PoctAdressId;

        await _userManager.UpdateAsync(currentUser);

        response.Status = true;
        response.Message = "Sizin məlumatlar uğurla dəyişdirildi";
        return response;
    }

    public async Task<AuthenticationResultDto> VerifyEmail(string email, string token)
    {
        AppUser user=await _userManager.FindByEmailAsync(email);

        await _userManager.ConfirmEmailAsync(user, token);
        string tokenjwt = _jwtService.JwtTokenGenerator(user);
        AuthenticationResultDto authenticationResultDto = _mapper.Map<AuthenticationResultDto>(user);
        authenticationResultDto.JwtToken = tokenjwt;
        return authenticationResultDto;
    }
}

