
using Microsoft.AspNetCore.Hosting;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Configuration;
using System.Net;
using System.Net.Mail;

public class EmailService : IEmailService
{
    private readonly IWebHostEnvironment _env;

    public EmailService(IWebHostEnvironment env)
    {
        _env = env;
    }
    public async Task SendEmail(string email, string token,string subject)
    {
        
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("memmedlievez07@gmail.com", "Straex");
        mail.To.Add(new MailAddress(email));
        string body = string.Empty;
        var path2 = Path.Combine(_env.WebRootPath,"Template","htmlpage.html");

        using (StreamReader reader = new StreamReader(path2))
        {
            body = reader.ReadToEnd();

        }
        mail.Subject = subject;
        mail.IsBodyHtml = true;
        mail.Body = body.Replace("{{Token}}",token);
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.EnableSsl = true;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.Credentials = new NetworkCredential("memmedlievez07@gmail.com", "mvzwqnnuucovswhe");
        try
        {
            smtp.Send(mail);
        }
        catch (Exception)
        {

            throw;
        }
    }
}
