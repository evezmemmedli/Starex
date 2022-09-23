using FluentValidation;
public class AdvantagePostDtoValidation:AbstractValidator<AdvantagePostDto>
{
    public AdvantagePostDtoValidation()
    {
        RuleFor(x => x.Icon).NotEmpty().WithMessage("Please fill this field");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Please fill this field").MaximumLength(50).WithMessage("Title must be maximum 50 character");
    }
}

