using FluentValidation;
public class LoginDtoValidation : AbstractValidator<LoginDto>
{
    public LoginDtoValidation()
    {
        RuleFor(l=>l.Email).NotEmpty();
        RuleFor(l=>l.Password).NotEmpty();

    }
}

