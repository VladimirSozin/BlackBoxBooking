using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Services.Policies;

namespace Vacation.Core.Domain.Factories;

/// <summary>
/// Factory for creating policy services.
/// </summary>
public class PolicyFactory
{
    /// <summary>
    /// Creates a policy service based on the policy.
    /// </summary>
    /// <param name="policy">The policy.</param>
    /// <returns>The policy service.</returns>
    public static IPolicyService CreatePolicy(Policy policy)
    {
        ArgumentNullException.ThrowIfNull(policy);
        
        IPolicyService? policyService;
        switch (policy.Code)
        {
            case "beforeNYDeny":
                policyService = new BeforeNYDenyPolicyService(policy);
                break;
            default:
                throw new InvalidOperationException($"code {policy.Code} not supported");
        }

        return policyService;
    }
}
