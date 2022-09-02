
using Microsoft.AspNetCore.Http;

public class NewsPostDto
{
    public IFormFile Image { get; set; }
    public string Title { get; set; }
    public string Desc { get; set; }
}

