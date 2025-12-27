using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services;

public class UserService : IUserService
{
    private readonly IRepository<Employee> _repository;
    private readonly IConfiguration _configuration;

    public UserService(IRepository<Employee> repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }

    public async Task<Result<bool>> Auth(string username, string password)
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(_configuration["JWT:salt"]),
            iterations: 10000, HashAlgorithmName.SHA256);
        byte[] hashBytes = pbkdf2.GetBytes(32);

        string hash = Convert.ToBase64String(hashBytes);
        Result<IReadOnlyList<Employee>> userListResult =
            await _repository.GetAsync(c => c.Username == username && c.Password == hash);
        if (userListResult.IsSuccess)
        {
            if (userListResult.Data?.Count == 0)
            {
                return new Result<bool>().AddError("login or password is incorrect");
            }

            return new Result<bool>();
        }

        return new Result<bool>().AddError(userListResult.GetErrorsString());
    }
}