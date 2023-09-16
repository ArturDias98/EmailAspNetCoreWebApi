using EmailAspNetCore.Contracts;

namespace EmailAspNetCore.Services;

internal class EmailService : IEmailService
{
    public Task SendAsync(string subject, string body, IEnumerable<string> to, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
