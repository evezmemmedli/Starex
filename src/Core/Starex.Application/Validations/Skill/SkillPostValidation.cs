using FluentValidation;
public class SkillPostValidation :AbstractValidator<SkillPostDto>
{
    public SkillPostValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Please fill this field").MaximumLength(50).WithMessage("Name must be maximum 50 character");
    }
}

