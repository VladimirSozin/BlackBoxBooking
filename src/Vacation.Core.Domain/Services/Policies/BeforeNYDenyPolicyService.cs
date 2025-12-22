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
    /// <param name="vacation">The request.</param>
    /// <returns>True if the request is allowed, otherwise false.</returns>
    public bool Apply(Entities.Vacation vacation)
    {
        //это хардкод, просто для ясности
        if (Policy.DepartmentId == 1 && vacation.DateStart.Month == 12 && vacation.DateStart.Day >= 14)
        {
            return false;
        }
        return true;
    }
}
