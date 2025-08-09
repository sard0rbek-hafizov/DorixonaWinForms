using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Dorixona.Infrastructure.Authentication.Jwt;

public class JwtTokenValidator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenValidator(IOptions<JwtSettings> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
    }

    public bool ValidateToken(string token, out JwtSecurityToken? validatedToken)
    {
        validatedToken = null;
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = _jwtSettings.Audience,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero
            }, out var securityToken);

            validatedToken = securityToken as JwtSecurityToken;
            return true;
        }
        catch
        {
            return false;
        }
    }
}