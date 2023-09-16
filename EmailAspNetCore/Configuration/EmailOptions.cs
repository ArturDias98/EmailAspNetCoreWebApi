namespace EmailAspNetCore.Configuration;

internal class EmailOptions
{
    public const string Section = "Email";
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
