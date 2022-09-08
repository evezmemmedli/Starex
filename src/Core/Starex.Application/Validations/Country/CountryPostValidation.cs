using FluentValidation;
public class CountryPostValidation: AbstractValidator<CountryPostDto>
{
    public CountryPostValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Please fill this field").MaximumLength(30).WithMessage("This field maximum length must be 30 character");

    }
}

