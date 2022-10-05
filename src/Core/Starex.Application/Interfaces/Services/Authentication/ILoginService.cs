
public interface ILoginService
{
    public Task<AuthenticationResultDto> Login(LoginDto dto);
    public Task<AuthenticationResultDto> LoginUser(LoginDto dto);

    public Task<string> ForgetPasswordAsync(string email);
    public Task ResetPasswordAsync(ResetPasswordDto dto);
}

