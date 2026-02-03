using Vacation.Core.Auth.Entities;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Auth.Services;

public class InMemoryRefreshTokenStore : IRefreshTokenStore
{
    private static readonly Dictionary<string, (string Username, RefreshToken Token)> _tokens = new();

    public async Task<Result<bool>> AddTokenAsync(string username, RefreshToken token)
    {
        _tokens[token.Token] = (username, token);
        return await Task.FromResult(new Result<bool>());
    }

    public async Task<Result<RefreshToken>> GetTokenAsync(string token)
    {
        if (_tokens.TryGetValue(token, out var entry))
        {
            return await Task.FromResult(new Result<RefreshToken>() { Data = entry.Token });
        }

        return await Task.FromResult(new Result<RefreshToken>().AddError("Token not found"));
    }

    public async Task<Result<bool>> RevokeToken(string token)
    {
        if (_tokens.ContainsKey(token))
        {
            _tokens[token] = (_tokens[token].Username, new RefreshToken
            {
                Token = _tokens[token].Token.Token,
                Expires = _tokens[token].Token.Expires,
                Created = _tokens[token].Token.Created,
                CreatedByIp = _tokens[token].Token.CreatedByIp,
                Revoked = DateTime.UtcNow
            });
            return await Task.FromResult(new Result<bool>());
        }

        return await Task.FromResult(new Result<bool>().AddError("User not found"));
    }
}