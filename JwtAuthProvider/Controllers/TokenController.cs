// This document was formatted and refined by AI
using JwtAuthProvider.Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthProvider.Controllers;

/// <summary>
/// Controller responsible for issuing JWT tokens to authenticated clients.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TokenController : ControllerBase
{
    private readonly IJwtTokenService _tokenService;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="TokenController"/> class.
    /// </summary>
    /// <param name="tokenService">Service for generating JWT tokens.</param>
    /// <param name="configuration">Application configuration for accessing settings such as API keys.</param>
    public TokenController(IJwtTokenService tokenService, IConfiguration configuration)
    {
        _tokenService = tokenService;
        _configuration = configuration;
    }

    /// <summary>
    /// Issues a JWT token if the provided API key and user credentials are valid.
    /// </summary>
    /// <param name="request">The token request containing the user ID and admin status.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing the JWT token if authentication is successful;
    /// otherwise, an unauthorized result.
    /// </returns>
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
