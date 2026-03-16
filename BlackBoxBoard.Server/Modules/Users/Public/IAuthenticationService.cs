using BlackBoxBoard.Server.Modules.Users.Application.DTOs;

namespace BlackBoxBoard.Server.Modules.Users.Public;

public interface IAuthenticationService
{
    Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request, string ipAddress);
    Task<AuthResponseDto> LoginAsync(LoginRequestDto request, string ipAddress);
    Task<AuthResponseDto> RefreshTokenAsync(string refreshToken, string ipAddress);
    Task RevokeTokenAsync(string refreshToken, string ipAddress);
}