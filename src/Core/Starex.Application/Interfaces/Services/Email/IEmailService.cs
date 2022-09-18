
public interface IEmailService
{
    public Task SendEmail(string email, string token,string subject);
}

