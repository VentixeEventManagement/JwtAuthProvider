// This document was formatted and refined by AI
namespace JwtAuthProvider.Infrastructure.Authentication;

/// <summary>
/// Provides functionality for generating JSON Web Tokens (JWT) for authentication purposes.
/// </summary>
public interface IJwtTokenService
{
    /// <summary>
    /// Generates a JWT token for the specified user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user for whom the token is generated.</param>
    /// <param name="isAdmin">Indicates whether the user has administrative privileges.</param>
    /// <returns>
    /// A JWT token as a string representing the user's authentication and authorization claims.
    /// </returns>
    string GenerateToken(string userId, bool isAdmin);
}