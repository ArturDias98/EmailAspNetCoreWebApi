namespace EmailAspNetCore.Models;

public class EmailModel
{
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public bool IsMarkDown { get; set; }
    public IEnumerable<string> To { get; set; } = Enumerable.Empty<string>();
}
