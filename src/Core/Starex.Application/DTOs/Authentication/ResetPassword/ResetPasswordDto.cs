
using FluentValidation;

public class ResetPasswordDto
{
    public string Token { get;set; }
    public string Email { get;set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

public class ResetPasswordDtoValidation : AbstractValidator<ResetPasswordDto>
{
    public ResetPasswordDtoValidation()
    {
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.ConfirmPassword).NotEmpty();

        RuleFor(x =>x).Custom((x, context) => {
            if (x.Password != x.ConfirmPassword)
                context.AddFailure("ConfirmPassword", "ConfirmPassword not match");
        });
    }
}