using System.Collections.Generic;
using System.Threading.Tasks;
using Vacation.Core.Application.Dto;
using Vacation.Core.Application.Dto.Requests;
using Vacation.Core.Domain.Entities;
using Vacation.Core.Application.Factories;
using Vacation.Core.Domain.Services;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Application.Aggregates;

public class RegistrateVacationAggregate : IVacationRegistratorAggregate
{
    private readonly IRepository<Domain.Entities.Vacation> _requestRepository;
    private readonly IPolicyApplicatorService _policyApplicatorService;
    private readonly IWorkFlowAggregate _workFlowAggregate;

    public RegistrateVacationAggregate(IRepository<Domain.Entities.Vacation> requestRepository,
        IPolicyApplicatorService policyApplicatorService, IWorkFlowAggregate workFlowAggregate)
    {
        _requestRepository = requestRepository;
        _policyApplicatorService = policyApplicatorService;
        _workFlowAggregate = workFlowAggregate;
    }

    public async Task<Result<bool>> RegistrateAsync(int vacationId)
    {
        Result<bool> result = new();

        Result<IReadOnlyList<Domain.Entities.Vacation>> getRequestResult =
            await _requestRepository.GetAsync(c => c.Id == vacationId).ConfigureAwait(false);
        if (!getRequestResult.IsSuccess)
        {
            return result.AddError(getRequestResult.GetErrorsString());
        }

        if (getRequestResult.Data[0] is Domain.Entities.Vacation request)
        {
            Result<bool> policyResult =
                await _policyApplicatorService.ApplyPoliciesAsync(request).ConfigureAwait(false);

            if (!policyResult.IsSuccess)
            {
                return result.AddError(policyResult.GetErrorsString());
            }

            if (!policyResult.Data)
            {
                return result.AddError("the request is rejected");
            }

            return result;
        }

        return result.AddError("the request isn't found");
    }

    public async Task<Result<bool>> SaveVacationAsync(CreateVacationRequestDto dto)
    {
        Result<bool> result = new();
        Domain.Entities.Vacation vacation = RequestFactory.CreateRequest(dto);
        Result<Domain.Entities.Vacation> saveResult = await _requestRepository.SaveAsync(vacation).ConfigureAwait(false);
        if (!saveResult.IsSuccess)
        {
            return result.AddError(saveResult.GetErrorsString());
        }

        Result<bool> workFlowResult = await _workFlowAggregate.RunNextAsync(vacation).ConfigureAwait(false);
        if (!workFlowResult.IsSuccess)
        {
            return result.AddError(saveResult.GetErrorsString());
        }

        return result;
    }
}