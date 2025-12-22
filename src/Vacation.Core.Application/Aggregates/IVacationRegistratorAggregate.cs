using System.Threading.Tasks;
using Vacation.Core.Application.Dto;
using Vacation.Core.Application.Dto.Requests;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Application.Aggregates;

/// <summary>
/// Aggregate for registering requests.
/// </summary>
public interface IVacationRegistratorAggregate
{
    /// <summary>
    /// Registers a request asynchronously.
    /// </summary>
    /// <param name="vacationId">The vacation ID.</param>
    /// <returns>The result.</returns>
    Task<Result<bool>> RegistrateAsync(int vacationId);

    /// <summary>
    /// Saves a request asynchronously.
    /// </summary>
    /// <param name="dto">The request create DTO.</param>
    /// <returns>The result.</returns>
    Task<Result<bool>> SaveVacationAsync(CreateVacationRequestDto dto);
}
