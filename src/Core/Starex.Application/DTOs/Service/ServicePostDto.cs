using Microsoft.AspNetCore.Http;
public class ServicePostDto
{
    public IFormFile Photo { get; set; }
    public string Desc { get; set; }
    public string Title { get; set; }
    public string Icon { get; set; }
}

