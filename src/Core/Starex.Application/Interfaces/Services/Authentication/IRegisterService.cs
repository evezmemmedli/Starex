using Starex.Application.DTOs.Authentication;

public interface IRegisterService
{
    public Task Register(RegisterPostDto dto);

    public Task<AuthenticationResultDto> VerifyEmail(string email,string token);
    public Task<UpdateUserResponseDto> UpdateUserInformation(UpdatePostDto requestDto);
}

