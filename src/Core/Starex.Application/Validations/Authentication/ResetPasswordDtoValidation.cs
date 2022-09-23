using FluentValidation;
public class ResetPasswordDtoValidation : AbstractValidator<ResetPasswordDto>
{
    public ResetPasswordDtoValidation()
    {
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.ConfirmPassword).NotEmpty();
        RuleFor(x => x).Custom((x, context) =>
        {
            if (x.Password != x.ConfirmPassword)
                context.AddFailure("ConfirmPassword", "ConfirmPassword not match");
        });
    }
}