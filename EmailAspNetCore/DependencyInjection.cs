using EmailAspNetCore.Contracts;
using EmailAspNetCore.Options;
using EmailAspNetCore.Services;

namespace EmailAspNetCore;

internal static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddOptions()
            .AddTransient<IEmailService, EmailService>();
    }

    private static IServiceCollection AddOptions(this IServiceCollection services)
    {
        return services
            .ConfigureOptions<EmailOptionsSetup>();
    }
}
