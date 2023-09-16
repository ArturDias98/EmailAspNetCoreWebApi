using EmailAspNetCore.Contracts;
using EmailAspNetCore.Helpers;
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
            var parseBody = model.IsMarkDown
            ? MarkDownHelper.ToHtml(model.Body)
            : model.Body;

            await service.SendAsync(
                model.Subject,
                parseBody,
                model.To,
                token);

            return Results.Ok();
        });

        return app;
    }
}
