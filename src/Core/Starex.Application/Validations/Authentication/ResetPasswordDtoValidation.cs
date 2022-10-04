using FluentValidation;
public class ResetPasswordDtoValidation : AbstractValidator<ResetPasswordDto>
{
    public ResetPasswordDtoValidation()
    {
        RuleFor(r => r.Email).NotEmpty().WithMessage("Please fill this field");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Please fill this field");
        RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Please fill this field");
        RuleFor(x => x).Custom((x, context) =>
        {
            if (x.Password != x.ConfirmPassword)
                context.AddFailure("ConfirmPassword", "ConfirmPassword not match");
        });
    }
}