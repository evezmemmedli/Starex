using FluentValidation;
public class FaqPostDtoValidation : AbstractValidator<FaqPostDto>
{
    public FaqPostDtoValidation()
    {
        RuleFor(x=>x.Title).NotEmpty().WithMessage("Please fill this field").MaximumLength(30).WithMessage("Title length must be 30 character");
    }
}

