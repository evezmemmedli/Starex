using FluentValidation;
public class OrderPostDtoValidation:AbstractValidator<OrderPostDto>
{
    public OrderPostDtoValidation()
    {
        RuleFor(x=>x.Weight).NotEmpty ().WithMessage("Please fill this field");
        RuleFor(x => x.OrderLink).NotEmpty().WithMessage("Please fill this field");
    }
}

