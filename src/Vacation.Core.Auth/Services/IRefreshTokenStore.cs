using Vacation.Core.Auth.Entities;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Auth.Services;

public interface IRefreshTokenStore
{
    Task<Result<bool>> AddTokenAsync(string username, RefreshToken token);
    Task<Result<RefreshToken>> GetTokenAsync(string token);
    Task<Result<bool>> RevokeToken(string token);
}