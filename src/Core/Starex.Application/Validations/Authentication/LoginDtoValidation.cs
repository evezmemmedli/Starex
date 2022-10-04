using FluentValidation;
namespace Starex.Application.Validations.Authentication
{
    public class LoginDtoValidation : AbstractValidator<LoginDto>
    {
        public LoginDtoValidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Please fill this field").WithMessage("Fill this field");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please fill this field").WithMessage("Fill this field");
        }
    }
}

