using Vacation.Core.Domain.Entities;

namespace Vacation.Core.Domain.Services.Policies;

/// <summary>
/// Policy service for denying requests before New Year.
/// </summary>
public class BeforeNYDenyPolicyService : BasePolicyService, IPolicyService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BeforeNYDenyPolicyService"/> class.
    /// </summary>
    /// <param name="policy">The policy.</param>
    public BeforeNYDenyPolicyService(Policy policy) : base(policy)
    {

    }

    /// <summary>
    /// Applies the policy to the request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>True if the request is allowed, otherwise false.</returns>
    public bool Apply(Request request)
    {
        //это хардкод, просто для ясности
        if (Policy.DepartmentId == 1 && request.DateStart.Month == 12 && request.DateStart.Day >= 14)
        {
            return false;
        }
        return true;
    }
}
