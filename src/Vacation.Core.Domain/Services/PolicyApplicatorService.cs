using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Factories;
using Vacation.Core.Domain.Services.Policies;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services;

/// <summary>
/// Service for applying policies.
/// </summary>
public class PolicyApplicatorService : IPolicyApplicatorService
{
    private readonly IRepository<Policy> _policyRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="PolicyApplicatorService"/> class.
    /// </summary>
    /// <param name="policyRepository">The policy repository.</param>
    public PolicyApplicatorService(IRepository<Policy> policyRepository)
    {
        _policyRepository = policyRepository;
    }

    /// <summary>
    /// Applies policies asynchronously.
    /// </summary>
    /// <param name="vacation">The request.</param>
    /// <returns>The result.</returns>
    public async Task<Result<bool>> ApplyPoliciesAsync(Entities.Vacation vacation)
    {
        Result<bool> result = new();

        Result<IReadOnlyList<Policy>> getPolicyResult =
            await _policyRepository.GetAsync(c => c.DepartmentId == vacation.DepartmentId).ConfigureAwait(false);

        if (!getPolicyResult.IsSuccess)
        {
            return new Result<bool>().AddError(getPolicyResult.GetErrorsString());
        }

        bool isSucess = false;
        foreach (var policy in getPolicyResult.Data ?? [])
        {
            IPolicyService policyService = PolicyFactory.CreatePolicy(policy);
            isSucess &= policyService.Apply(vacation);
        }

        result.Data = isSucess;
        return result;
    }
}
