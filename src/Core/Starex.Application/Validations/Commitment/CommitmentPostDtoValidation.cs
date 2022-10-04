using FluentValidation;
public class CommitmentPostDtoValidation: AbstractValidator<CommitmentPostDto>
{
    public CommitmentPostDtoValidation()
    {
        RuleFor(x => x.Fullname).NotEmpty().WithMessage("Please fill this fiedl").MaximumLength(30).WithMessage("Maximum length must be 30 character ");
        RuleFor(x => x.IdentityNumber).NotEmpty().WithMessage("Please fill this field");
        RuleFor(x => x.AppUserId).NotEmpty().WithMessage("Please fill this field");
    }
}

