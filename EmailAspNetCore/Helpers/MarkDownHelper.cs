using Markdig;

namespace EmailAspNetCore.Helpers;

internal static class MarkDownHelper
{
    private static readonly MarkdownPipeline _pipeline =
        new MarkdownPipelineBuilder()
        .UseAdvancedExtensions()
        .Build();

    public static string ToHtml(string markdownText)
    {
        return Markdown.ToHtml(markdownText, _pipeline);
    }
}
