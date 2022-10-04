using FluentValidation;
public class LoginDtoValidation : AbstractValidator<LoginDto>
{
    public LoginDtoValidation()
    {
        RuleFor(l=>l.Email).NotEmpty().WithMessage("Please fill this field");
        RuleFor(l=>l.Password).NotEmpty().WithMessage("Please fill this field");
    }
}

