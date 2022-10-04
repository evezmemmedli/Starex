public class PoctAdressDto
{
    public string Adress { get; set; }
    public List<DeliveryPointInPoctAdressDto> DeliveryPoints { get; set; }
}
public class DeliveryPointInPoctAdressDto
{
    public int? DeliveryPointId { get; set; }
}

