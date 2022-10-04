using FluentValidation;
public class RegisterPostDtoValidation : AbstractValidator<RegisterPostDto>
{
    public RegisterPostDtoValidation()
    {
        RuleFor(r => r.Name).MaximumLength(20).WithMessage("Name must be maximum 20 character").NotEmpty().WithMessage("Please fill this field");
        RuleFor(r => r.Surname).MaximumLength(20).WithMessage("Surname must be maximum 20 character").NotEmpty().WithMessage("Please fill this field");
        RuleFor(r => r.Gender).MaximumLength(20).WithMessage("Gender must be maximum 20 character").NotEmpty().WithMessage("Please fill this field");
        RuleFor(r => r.Adress).MaximumLength(20).WithMessage("Adress must be maximum 20 character").NotEmpty().WithMessage("Please fill this field");
        RuleFor(r => r.IdentityNumber).MaximumLength(30).WithMessage("IdentityNumber must be maximum 30 character").NotEmpty().WithMessage("Please fill this field");
        RuleFor(r => r.Fin).MaximumLength(30).WithMessage("Fin must be maximum 30 character").NotEmpty().NotEmpty().WithMessage("Please fill this field");
        RuleFor(r => r.PhoneNumber).NotEmpty().WithMessage("Please fill this field");
        RuleFor(r => r.Password).NotEmpty().WithMessage("Please fill this field");
        RuleFor(r => r.ConfirmPassword).NotEmpty().WithMessage("Please fill this field");
        RuleFor(r => r.DeliveryPointId).NotEmpty().WithMessage("Please fill this field");
        RuleFor(r => r.PoctAdressId).NotEmpty().WithMessage("Please fill this field");
        RuleFor(r => r.DateOfBirth).NotEmpty().WithMessage("Please fill this field");
        RuleFor(r => r.Email).MaximumLength(20).NotEmpty().EmailAddress(mode: FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);
        RuleFor(r => r).Custom((r, context) =>
        {
            if (r.Password != r.ConfirmPassword)
                context.AddFailure("ConfirmPassword", "Password not match with password");
            //context.AddFailure(new FluentValidation.Results.ValidationFailure("Password", "Password and confirm password doesnt match"));
        });
    }
}

