// This document was formatted and refined by AI
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
     
        if (!Request.Headers.TryGetValue("X-API-KEY", out var apiKeyHeader))
        {
            return Unauthorized("API key header is missing");
        }

        var expectedApiKey = _configuration["ApiKey"];
        if (string.IsNullOrEmpty(expectedApiKey) || apiKeyHeader != expectedApiKey)
        {
            return Unauthorized("Invalid API key");
        }

       
        var token = _tokenService.GenerateToken(request.UserId, request.IsAdmin);

        return Ok(new { token });
    }
}