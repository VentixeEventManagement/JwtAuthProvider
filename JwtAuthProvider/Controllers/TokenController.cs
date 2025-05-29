using JwtAuthProvider.Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthProvider.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TokenController : ControllerBase
{
    private readonly IJwtTokenService _tokenService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<TokenController> _logger;

    public TokenController(
        IJwtTokenService tokenService,
        IConfiguration configuration,
        ILogger<TokenController> logger)
    {
        _tokenService = tokenService;
        _configuration = configuration;
        _logger = logger;
    }

    [HttpPost]
    public IActionResult GetToken([FromBody] TokenRequest request)
    {
        // In a real application, validate credentials against a database
        // For now, we'll accept any username/password (as mentioned, security will be added later)

        _logger.LogInformation("Token requested for user: {Username}", request.Username);

        // Generate token with some default roles (you can customize this later)
        var token = _tokenService.GenerateToken(request.Username, new[] { "User" });

        var expiryMinutes = Convert.ToDouble(_configuration["Jwt:ExpiryInMinutes"] ?? "60");

        return Ok(new TokenResponse
        {
            Token = token,
            Expiration = DateTime.UtcNow.AddMinutes(expiryMinutes)
        });
    }
}