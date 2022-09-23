using FluentValidation;
public class NewsPostDtoValidation:AbstractValidator<NewsPostDto>
{
    public NewsPostDtoValidation()
    {
        RuleFor(x => x.Image).NotEmpty().WithMessage("Please add image");
        RuleFor(x => x.Desc).NotEmpty().WithMessage("Please fill this field").MaximumLength(5000).WithMessage("Text must be maximum 5000 character");
        RuleFor(x=>x.Title).NotEmpty().WithMessage("Please fill this field").MaximumLength(100).WithMessage("Text must be maximum 5000 character");
    }
}

