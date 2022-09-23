using FluentValidation;
public class SettingPostDtoValidation:AbstractValidator<SettingPostDto>
{
    public SettingPostDtoValidation()
    {
        RuleFor(x => x.Icon).NotEmpty().WithMessage("Please fill this field");
        RuleFor(x => x.SocialMedia).NotEmpty().WithMessage("Please fill this field");
        RuleFor(x => x.Contact).NotEmpty().WithMessage("Please fill this field");
    }
}

