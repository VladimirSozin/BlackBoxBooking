using Vacation.Core.Domain.Entities;

namespace Vacation.Core.Domain.Services.Policies;

/// <summary>
/// Policy service interface.
/// </summary>
public interface IPolicyService
{
    /// <summary>
    /// Applies the policy.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>True if the request is allowed, otherwise false.</returns>
    bool Apply(Request request);
}
