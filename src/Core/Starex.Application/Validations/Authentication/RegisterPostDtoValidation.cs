using FluentValidation;
public class RegisterPostDtoValidation : AbstractValidator<RegisterPostDto>
{
    public RegisterPostDtoValidation()
    {
        RuleFor(r => r.Name).MaximumLength(20).NotEmpty();
        RuleFor(r => r.Surname).MaximumLength(20).NotEmpty();
        RuleFor(r => r.Gender).MaximumLength(20).NotEmpty();
        RuleFor(r => r.Adress).MaximumLength(20).NotEmpty();
        RuleFor(r => r.IdentityNumber).MaximumLength(30).NotEmpty();
        RuleFor(r => r.Fin).MaximumLength(30).NotEmpty();
        RuleFor(r => r.PhoneNumber).NotEmpty();
        RuleFor(r => r.Email).NotEmpty();
        RuleFor(r => r.Password).NotEmpty();
        RuleFor(r => r.ConfirmPassword).NotEmpty();
        RuleFor(r => r.DeliveryPointId).NotEmpty();
        RuleFor(r => r.PoctAdressId).NotEmpty();
        RuleFor(r => r.DateOfBirth).NotEmpty();
        RuleFor(r => r.Email).MaximumLength(20).NotEmpty().EmailAddress(mode: FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);
        RuleFor(r => r).Custom((r, context) =>
        {
            if (r.Password != r.ConfirmPassword)
                context.AddFailure("ConfirmPassword", "Password not match with password");
            //context.AddFailure(new FluentValidation.Results.ValidationFailure("Password", "Password and confirm password doesnt match"));
        });
    }
}

