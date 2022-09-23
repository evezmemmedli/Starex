using FluentValidation;
public class DeliveryPointPostDtoValidations : AbstractValidator<DeliveryPointPostDto>
{
    public DeliveryPointPostDtoValidations()
    {
        RuleFor(x => x.Adress).NotEmpty().WithMessage("Please fill this field").MaximumLength(30).WithMessage("Maximum length must be 30 character");
        RuleFor(x => x.ActiveHour).NotEmpty().WithMessage("Please fill this field");
    }
}

