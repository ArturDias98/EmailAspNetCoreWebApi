using EmailAspNetCore.Contracts;
using EmailAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailAspNetCore.Extensions;

internal static class EmailDependencyInjection
{
    public static WebApplication MapEmailEndpoints(this WebApplication app)
    {
        app.MapPost("api/v1/email", async (
            [FromBody] EmailModel model,
            [FromServices] IEmailService service,
            CancellationToken token) =>
        {
            await service.SendAsync(
                model.Subject,
                model.Body,
                model.To,
                token);

            return Results.Ok();
        });

        return app;
    }
}
