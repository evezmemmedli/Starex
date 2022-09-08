using FluentValidation;
public class BrandPostDtoValidation : AbstractValidator<BrandPostDto>
{
    public BrandPostDtoValidation()
    {
        RuleFor(b => b.Name).NotEmpty().WithMessage("Please fill this field").MaximumLength(30).WithMessage("Maximum character must be 30");
        RuleFor(b => b.Title).NotEmpty().WithMessage("Please fill this field").MaximumLength(200).WithMessage("Maximum character must be 200");
        RuleFor(b => b.Desc).NotEmpty().WithMessage("Please fill this field").MaximumLength(5000).WithMessage("Maximum character must be 200");
        RuleFor(b => b.Cashback).NotEmpty().WithMessage("Please fill this field").LessThanOrEqualTo(9999.99m).GreaterThanOrEqualTo(1);
        RuleFor(b => b.Image).NotEmpty().WithMessage("Please fill this field");
       
    }
}

