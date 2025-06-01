// This document was formatted and refined by AI
namespace JwtAuthProvider.Infrastructure.Authentication;

public interface IJwtTokenService
{
    string GenerateToken(string userId, bool isAdmin);
}