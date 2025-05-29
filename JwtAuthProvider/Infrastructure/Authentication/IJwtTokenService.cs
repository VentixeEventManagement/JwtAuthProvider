// JwtAuthProvider/Infrastructure/Authentication/IJwtTokenService.cs
namespace JwtAuthProvider.Infrastructure.Authentication;

public interface IJwtTokenService
{
    string GenerateToken(string userId, bool isAdmin);
}