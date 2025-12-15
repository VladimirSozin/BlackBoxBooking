using System.Threading.Tasks;
using Vacation.Core.Application.Dto;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Application.Aggregates;

/// <summary>
/// Aggregate for registering requests.
/// </summary>
public interface IRequestRegistratorAggregate
{
    /// <summary>
    /// Registers a request asynchronously.
    /// </summary>
    /// <param name="requestId">The request ID.</param>
    /// <returns>The result.</returns>
    Task<Result<bool>> RegistrateRequestAsync(int requestId);

    /// <summary>
    /// Saves a request asynchronously.
    /// </summary>
    /// <param name="dto">The request create DTO.</param>
    /// <returns>The result.</returns>
    Task<Result<bool>> SaveRequestAsync(RequestCreateDto dto);
}
