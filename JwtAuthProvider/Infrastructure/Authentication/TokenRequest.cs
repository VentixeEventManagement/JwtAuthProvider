// This document was formatted and refined by AI
namespace JwtAuthProvider.Infrastructure.Authentication;

/// <summary>
/// Represents a request to generate a JWT token for a user.
/// </summary>
public class TokenRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the user requesting the token.
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user has administrative privileges.
    /// </summary>
    public bool IsAdmin { get; set; }
}
