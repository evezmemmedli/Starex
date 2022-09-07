using FluentValidation;
public class FaqQuestionPostValidator : AbstractValidator<FaqQuestionPostDto>
{
    public FaqQuestionPostValidator()
    {
        RuleFor(x=>x.Question).NotEmpty().WithMessage("Please fill this field").MaximumLength(100).WithMessage("Question lenght must be maximum 100 character");
        RuleFor(x=>x.Answer).NotEmpty().WithMessage("Please fill this field").MaximumLength(5000).WithMessage("Question lenght must be maximum 5000 character");
    }
}

