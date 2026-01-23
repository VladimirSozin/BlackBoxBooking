using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Vacation.Core.Auth.Dto;
using Vacation.Core.Auth.Entities;
using Vacation.Core.Auth.Services;
using Vacation.Core.Domain.Helpers;
using Vacation.Core.Domain.Services;

namespace Vacation.Core.Auth.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IRefreshTokenStore _refreshTokenStore;
    private readonly IUserService _userService;

    public AuthController(IConfiguration configuration, IRefreshTokenStore refreshTokenStore, IUserService userService)
    {
        _configuration = configuration;
        _refreshTokenStore = refreshTokenStore;
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        Result<bool> authResult = await _userService.Auth(loginDto.Username, loginDto.Password);
        if (authResult.IsSuccess) 
        {
            var (accessToken, refreshToken) =
                GenerateTokens(loginDto.Username, HttpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty);
            return Ok(new { AccessToken = accessToken, RefreshToken = refreshToken });
        }
        return Unauthorized(authResult.GetErrorsString());
    }

    private (string AccessToken, string RefreshToken) GenerateTokens(string username, string ip)
    {
        var accessToken = GenerateJwtToken(username);
        var refreshToken = Guid.NewGuid().ToString();

        var refreshTokenObj = new RefreshToken
        {
            Token = refreshToken,
            Expires = DateTime.UtcNow.AddDays(7),
            Created = DateTime.UtcNow,
            CreatedByIp = ip
        };

        _refreshTokenStore.AddTokenAsync(username, refreshTokenObj);

        return (accessToken, refreshToken);
    }

    private string GenerateJwtToken(string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "user")
            }),
            Expires = DateTime.UtcNow.AddHours(72),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}