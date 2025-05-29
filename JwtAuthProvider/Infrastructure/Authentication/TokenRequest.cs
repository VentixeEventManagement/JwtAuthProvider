// JwtAuthProvider/Infrastructure/Authentication/TokenRequest.cs
namespace JwtAuthProvider.Infrastructure.Authentication;

public class TokenRequest
{
    public required string UserId { get; set; }
    public bool IsAdmin { get; set; }
}