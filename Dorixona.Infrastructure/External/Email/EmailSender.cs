using System.Net;
using System.Net.Mail;

namespace Dorixona.Infrastructure.External.Email;

public interface IEmailSender
{
    Task SendEmailAsync(string toEmail, string subject, string body);
}

public class EmailSender : IEmailSender
{
    private readonly EmailSettings _settings;

    public EmailSender(EmailSettings settings)
    {
        _settings = settings;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        using var message = new MailMessage()
        {
            From = new MailAddress(_settings.SenderEmail, _settings.SenderName),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        message.To.Add(toEmail);

        using var client = new SmtpClient(_settings.SmtpServer, _settings.Port)
        {
            Credentials = new NetworkCredential(_settings.Username, _settings.Password),
            EnableSsl = _settings.UseSsl
        };

        await client.SendMailAsync(message);
    }
}