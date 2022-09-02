
using FluentValidation;

public class PoctAdressPostDto
{
    public string Adress { get; set; }
    public int DeliveryPointId { get; set; }
    public DeliveryPointDto DeliveryPoint { get; set; }
}

public class PoctAdressPostValidator : AbstractValidator<PoctAdressPostDto>
{
    public PoctAdressPostValidator()
    {
        RuleFor(x => x.Adress).NotEmpty();
        RuleFor(x => x.DeliveryPointId).NotEmpty();
    }
}

