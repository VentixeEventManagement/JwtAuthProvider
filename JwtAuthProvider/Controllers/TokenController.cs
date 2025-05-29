// JwtAuthProvider/Controllers/TokenController.cs
using JwtAuthProvider.Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthProvider.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TokenController : ControllerBase
{
    private readonly IJwtTokenService _tokenService;
    private readonly IConfiguration _configuration;

    public TokenController(IJwtTokenService tokenService, IConfiguration configuration)
    {
        _tokenService = tokenService;
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult GetToken([FromBody] TokenRequest request)
    {
        // Verify the API key from the X-API-KEY header
        if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKeyHeader))
        {
            return Unauthorized("API key header is missing");
        }

        var expectedApiKey = _configuration["ApiKey"];
        if (string.IsNullOrEmpty(expectedApiKey) || apiKeyHeader != expectedApiKey)
        {
            return Unauthorized("Invalid API key");
        }

        // Generate the JWT token
        var token = _tokenService.GenerateToken(request.UserId, request.IsAdmin);

        return Ok(new { token });
    }
}