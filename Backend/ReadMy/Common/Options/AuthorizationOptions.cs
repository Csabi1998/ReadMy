namespace Common.Options;

public class AuthorizationOptions
{
    public string JwtKey { get; set; } = default!;
    public int DefaultExpirationInMinutes { get; set; } = default!;
    public int RefreshExpirityInMinutes { get; set; } = default!;
    public int InternalCommunicatonExpirationMinutes { get; set; }
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
}
