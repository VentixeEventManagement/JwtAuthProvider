// JwtAuthProvider/Infrastructure/Authentication/JwtTokenService.cs
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthProvider.Infrastructure.Authentication;

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;

    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(string userId, bool isAdmin)
    {
        var jwtKey = _configuration["Jwt:Key"] ??
            throw new InvalidOperationException("JWT key is not configured");
        var issuer = _configuration["Jwt:Issuer"] ??
            throw new InvalidOperationException("JWT issuer is not configured");
        var audience = _configuration["Jwt:Audience"] ??
            throw new InvalidOperationException("JWT audience is not configured");

        // Parse expiry time from configuration or use default
        if (!int.TryParse(_configuration["Jwt:ExpiryInMinutes"], out int expiryInMinutes))
        {
            expiryInMinutes = 15; // Default to 15 minutes
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, isAdmin ? "Admin" : "User")
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}