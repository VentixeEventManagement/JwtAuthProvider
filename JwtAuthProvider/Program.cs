// This document was formatted and refined by AI
using JwtAuthProvider.Infrastructure.Authentication;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

/// <summary>
/// Entry point for the JWT Auth Provider API application.
/// Configures services, middleware, and the HTTP request pipeline.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Registers an HTTP client for making outbound HTTP requests.
/// </summary>
builder.Services.AddHttpClient();

/// <summary>
/// Registers the JWT token service as a singleton for dependency injection.
/// </summary>
builder.Services.AddSingleton<IJwtTokenService, JwtTokenService>();

/// <summary>
/// Configures CORS to allow requests from specified frontend origins.
/// </summary>
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(builder.Configuration["AllowedOrigins"]?.Split(',') ??
                           new[] { "http://localhost:3000" })
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

/// <summary>
/// Adds controller support for handling API requests.
/// </summary>
builder.Services.AddControllers();

/// <summary>
/// Adds support for API endpoint discovery.
/// </summary>
builder.Services.AddEndpointsApiExplorer();

/// <summary>
/// Configures Swagger/OpenAPI for API documentation and adds API key security definition.
/// </summary>
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWT Auth Provider API",
        Version = "v1",
        Description = "This API provides endpoints for generating and validating JSON Web Tokens (JWT) to enable secure client-server authentication. " +
              "Currently, all requests require a static API key provided in the 'X-API-KEY' header for authorization. " +
              "In the future, this API will be updated so that a JWT token is generated when a user logs in, and that token will be used for authenticating subsequent requests. " +
              "The static API key approach helps prevent unauthorized access during initial development, but it is recommended to transition to JWT-based authentication for production environments. " +
              "Refer to the endpoint documentation for details on required request and response formats."



    });

    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "API Key Authentication",
        Name = "X-API-KEY",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme"
    });

    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };

    var requirement = new OpenApiSecurityRequirement
    {
        { scheme, new List<string>() }
    };

    c.AddSecurityRequirement(requirement);
});

var app = builder.Build();

/// <summary>
/// Enables Swagger UI and documentation in the development environment.
/// </summary>
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWT Auth Provider API v1");
    });
}

/// <summary>
/// Enforces HTTPS redirection for all requests.
/// </summary>
app.UseHttpsRedirection();

/// <summary>
/// Applies the configured CORS policy.
/// </summary>
app.UseCors("AllowFrontend");

/// <summary>
/// Enables authorization middleware.
/// </summary>
app.UseAuthorization();

/// <summary>
/// Maps controller endpoints to the request pipeline.
/// </summary>
app.MapControllers();

/// <summary>
/// Runs the application.
/// </summary>
app.Run();

/// <summary>
/// Partial Program class for integration testing and entry point reference.
/// </summary>
public partial class Program { }
