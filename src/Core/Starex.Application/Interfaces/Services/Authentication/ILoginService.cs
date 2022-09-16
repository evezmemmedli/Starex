
public interface ILoginService
{
    public Task<AuthenticationResultDto> Login(LoginDto dto);
}

