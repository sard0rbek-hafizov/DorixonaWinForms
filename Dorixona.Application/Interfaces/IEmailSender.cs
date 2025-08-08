namespace Dorixona.Application.Interfaces;

public interface IEmailSender
{
    Task<bool> SendEmailAsync(
        string toEmail,
        string subject,
        string body,
        CancellationToken cancellationToken = default);
}