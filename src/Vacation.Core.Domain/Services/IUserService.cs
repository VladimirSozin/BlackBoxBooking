using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services;

public interface IUserService
{
    Task<Result<bool>> Auth(string username, string password);
}