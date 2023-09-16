namespace EmailAspNetCore.Contracts;

public interface IEmailService
{
    Task SendAsync(string subject, string body, IEnumerable<string> to, CancellationToken cancellationToken = default);
}
