using EmailAspNetCore.Configuration;
using EmailAspNetCore.Contracts;
using Microsoft.Extensions.Options;

namespace EmailAspNetCore.Services;

internal class EmailService : IEmailService
{
    private readonly EmailOptions _options;

    public EmailService(IOptions<EmailOptions> options)
    {
        _options = options.Value;
    }

    public Task SendAsync(string subject, string body, IEnumerable<string> to, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
