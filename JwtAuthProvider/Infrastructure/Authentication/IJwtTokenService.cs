using System.Security.Claims;

namespace JwtAuthProvider.Infrastructure.Authentication
{
    public interface IJwtTokenService
    {
        string GenerateToken(IEnumerable<Claim> claims);
        string GenerateToken(string username, IEnumerable<string> roles);
    }
}