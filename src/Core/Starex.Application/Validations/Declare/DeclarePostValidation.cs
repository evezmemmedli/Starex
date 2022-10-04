using FluentValidation;
public class DeclarePostValidation : AbstractValidator<DeclarePostDto>
{
    public DeclarePostValidation()
    {
        RuleFor(x => x.Condition).NotEmpty().WithMessage("Please fill this field");
        RuleFor(x => x.ProductPrice).NotEmpty().WithMessage("Please fill this field");
        RuleFor(x => x.Brand).NotEmpty().WithMessage("Please fill this field");
    }
}

