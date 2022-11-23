using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Common.Authorization;
using Common.Interfaces;
using Common.Options;

using IdentityModel;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Common.Services;

public class JwtTokenService : IJwtTokenService
{
    private readonly AuthorizationOptions _options;

    public JwtTokenService(IOptionsSnapshot<AuthorizationOptions> options)
    {
        _options = options.Value;
    }

    public string CreateToken(string userId, string userName, string name, string role)
    {
        var claims = CreateBaseClaims(userId, userName, name, role);

        return CreateToken(claims);
    }
    private List<Claim> CreateBaseClaims(string userId, string userName, string name, string role)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtClaimTypes.Id, userId),
            new Claim(JwtClaimTypes.Name, userName),
            new Claim(ReadMyClaims.FullName, name),
            new Claim(JwtClaimTypes.Role, role)
        };

        return claims;
    }

    public string CreateToken(IEnumerable<Claim> claims)
    {
        var time = TimeSpan.FromMinutes(_options.DefaultExpirationInMinutes);

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_options.JwtKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = _options.Audience,
            Issuer = _options.Issuer,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(time),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
