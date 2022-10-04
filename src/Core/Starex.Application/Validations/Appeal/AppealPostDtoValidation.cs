using FluentValidation;
public class AppealPostDtoValidation : AbstractValidator<AppealPostDto>
{
    public AppealPostDtoValidation()
    {
        RuleFor(x=>x.Message).NotEmpty().WithMessage("Please fill this field");
    }
}

