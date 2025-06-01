// This document was formatted and refined by AI
namespace JwtAuthProvider.Infrastructure.Authentication;

public class TokenRequest
{
    public required string UserId { get; set; }
    public bool IsAdmin { get; set; }
}