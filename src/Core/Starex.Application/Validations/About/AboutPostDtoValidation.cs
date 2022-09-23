using FluentValidation;
public class AboutPostDtoValidation : AbstractValidator<AboutPostDto>
{
    public AboutPostDtoValidation()
    {
        RuleFor(x => x.Desc).NotEmpty().MaximumLength(300);
        RuleFor(x => x.Photo).NotEmpty();
    }
}

