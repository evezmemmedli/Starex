using Microsoft.AspNetCore.Http;
public class BrandPostDto
{
    public int CountryId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Desc { get; set; }
    public IFormFile Image { get; set; }
    public decimal Cashback { get; set; }
}

