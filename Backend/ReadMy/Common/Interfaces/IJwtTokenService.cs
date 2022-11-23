using System.Security.Claims;

namespace Common.Interfaces;

public interface IJwtTokenService
{
    string CreateToken(string userId, string userName, string name, string role);

    string CreateToken(IEnumerable<Claim> claims);
}
