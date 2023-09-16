using EmailAspNetCore.Configuration;
using Microsoft.Extensions.Options;

namespace EmailAspNetCore.Options;

internal class EmailOptionsSetup : IConfigureOptions<EmailOptions>
{
    private readonly IConfiguration _configuration;

    public EmailOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(EmailOptions options)
    {
        _configuration
            .GetSection(EmailOptions.Section)
            .Bind(options);
    }
}
