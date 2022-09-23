using FluentValidation;
using Starex.Application.DTOs.Authentication;
public class UpdatePostDtoValidation : AbstractValidator<UpdatePostDto>
{
    public UpdatePostDtoValidation()
    {
        RuleFor(r => r.Name).MaximumLength(20).NotEmpty();
        RuleFor(r => r.Surname).MaximumLength(20).NotEmpty();
        RuleFor(r => r.Gender).MaximumLength(20).NotEmpty();
        RuleFor(r => r.Adress).MaximumLength(20).NotEmpty();
        RuleFor(r => r.IdentityNumber).MaximumLength(30).NotEmpty();
        RuleFor(r => r.Fin).MaximumLength(30).NotEmpty();
        RuleFor(r => r.PhoneNumber).NotEmpty();
        RuleFor(r => r.DeliveryPointId).NotEmpty();
        RuleFor(r => r.PoctAdressId).NotEmpty();
        RuleFor(r => r.DateOfBirth).NotEmpty();
        RuleFor(r => r.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.NewPassword).NotEmpty();
        RuleFor(x => x.NewConfirmPassword).NotEmpty();
        RuleFor(x => x).Custom((x, context) =>
        {
            if (x.NewPassword != x.NewConfirmPassword)
                context.AddFailure("ConfirmPassword", "ConfirmPassword not match");
        });
    }
}

