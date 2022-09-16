public interface IRegisterService
{
    public Task<AuthenticationResultDto> Register(RegisterPostDto dto); 
}

