using Microsoft.IdentityModel.Tokens;

namespace SuperMarketWebApi.Core.Settings;

public class JwtSettings
{
    public string SecretToken { get; set; }
}