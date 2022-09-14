using FluentValidation;
public class AboutSkillPostValidation : AbstractValidator<AboutSkillPostDto>
{
    public AboutSkillPostValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Please fill this field").MaximumLength(30).WithMessage("Name must be maximum 30 character");
    }
}

