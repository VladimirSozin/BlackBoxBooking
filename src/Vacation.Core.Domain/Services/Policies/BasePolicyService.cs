using Vacation.Core.Domain.Entities;

namespace Vacation.Core.Domain.Services.Policies;

/// <summary>
/// Base class for policy services.
/// </summary>
public class BasePolicyService
{
    /// <summary>
    /// Gets the policy.
    /// </summary>
    public readonly Policy Policy;

    /// <summary>
    /// Initializes a new instance of the <see cref="BasePolicyService"/> class.
    /// </summary>
    /// <param name="policy">The policy.</param>
    protected BasePolicyService(Policy policy)
    {
        Policy = policy;
    }
}
