
using FluentValidation;

public class PoctAdressPostDtoValidation:AbstractValidator<PoctAdressPostDto>
{
    public PoctAdressPostDtoValidation()
    {
        RuleFor(x => x.Adress).NotEmpty();
    }
}

