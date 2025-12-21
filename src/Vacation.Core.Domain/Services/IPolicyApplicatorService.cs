using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services;

/// <summary>
/// Service for applying policies.
/// </summary>
public interface IPolicyApplicatorService
{
    /// <summary>
    /// Applies policies asynchronous.
    /// </summary>
    /// <param name="vacation">The request.</param>
    /// <returns>The result.</returns>
    Task<Result<bool>> ApplyPoliciesAsync(Entities.Vacation vacation);
}
