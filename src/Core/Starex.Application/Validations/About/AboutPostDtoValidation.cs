using FluentValidation;
public class AboutPostDtoValidation : AbstractValidator<AboutPostDto>
{
    public AboutPostDtoValidation()
    {
        RuleFor(x => x.Desc).NotEmpty().MaximumLength(300).WithMessage("This field length must be maximum 300 character");
        RuleFor(x => x.Photo).NotEmpty();
    }
}

