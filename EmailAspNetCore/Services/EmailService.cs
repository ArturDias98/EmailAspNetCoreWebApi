using EmailAspNetCore.Configuration;
using EmailAspNetCore.Contracts;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace EmailAspNetCore.Services;

internal class EmailService : IEmailService
{
    private readonly EmailOptions _options;

    public EmailService(IOptions<EmailOptions> options)
    {
        _options = options.Value;
    }

    public async Task SendAsync(
        string subject,
        string body,
        IEnumerable<string> to,
        CancellationToken cancellationToken = default)
    {
        using var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_options.User));
        var parseTo = to.Select(i => MailboxAddress.Parse(i));
        email.To.AddRange(parseTo);

        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html) { Text = body };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(
            _options.Host,
            _options.Port,
            SecureSocketOptions.StartTls,
            cancellationToken);
        await smtp.AuthenticateAsync(
             _options.User,
             _options.Password,
             cancellationToken);
        await smtp.SendAsync(email);
    }
}
