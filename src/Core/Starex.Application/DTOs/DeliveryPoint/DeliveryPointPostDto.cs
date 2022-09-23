using FluentValidation;
public class DeliveryPointPostDto
{
    public string Adress { get; set; }
    public string ActiveHour { get; set; }
    public List<PoctAdressPostDto> poctAdressPostDtos { get; set; }
}


