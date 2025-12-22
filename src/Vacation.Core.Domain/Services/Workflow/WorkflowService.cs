using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Factories;
using Vacation.Core.Domain.Helpers;
using Vacation.Core.Domain.Services.Workflow.Steps;

namespace Vacation.Core.Domain.Services.Workflow;

/// <summary>
/// Main workflow service.
/// </summary>
public class MainWorkflowService : IWorkflowService
{
    private readonly IRepository<VacationHistory> _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWorkflowService"/> class.
    /// </summary>
    /// <param name="repository">The repository for history of approving requests.</param>
    public MainWorkflowService(IRepository<VacationHistory> repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gets the title of the workflow.
    /// </summary>
    /// <returns>The title.</returns>
    public string GetTitle()
    {
        return "Main";
    }


    private Dictionary<string, string> scheme = new()
    {
        { "first", "sending_email_to_boss" },
        { "sending_email_to_boss", "approving_by_boss" },
        { "approving_by_boss", "approving_by_big_boss" }
    };

    /// <summary>
    /// Runs the workflow asynchronously for the request.
    /// </summary>
    /// <param name="vacation">The request.</param>
    /// <returns>The result of running the workflow.</returns>
    public async Task<Result<bool>> RunAsync(Entities.Vacation vacation)
    {
        Result<IReadOnlyList<VacationHistory>> historyResult =
            await _repository.GetAsync(c => c.VacationId == vacation.Id).ConfigureAwait(false);

        if (!historyResult.IsSuccess)
        {
            return new Result<bool>().AddError(historyResult.GetErrorsString());
        }

        string nextStep;
        var last = historyResult.Data != null ? historyResult.Data[historyResult.Data.Count - 1] : null;
        if (last == null)
        {
            nextStep = scheme["first"];
        }
        else
        {
            nextStep = scheme[last.WorkFlowStepTitle];
        }

        IWorkflowStep step = WorkflowStepFactory.Create(nextStep);
        Result<bool> stepResult = step.RunStep(vacation);
        if (!stepResult.IsSuccess)
        {
            return new Result<bool>().AddError(stepResult.GetErrorsString());
        }

        Result<bool> saveResult = await SaveStepAsync(vacation, step.GetTitle()).ConfigureAwait(false);
        if (!saveResult.IsSuccess)
        {
            return new Result<bool>().AddError(saveResult.GetErrorsString());
        }

        return stepResult;
    }

    /// <summary>
    /// Saves the step asynchronously for the request.
    /// </summary>
    /// <param name="vacation">The request.</param>
    /// <param name="stepTitle">The step title.</param>
    /// <returns>The result of saving the step.</returns>
    public async Task<Result<bool>> SaveStepAsync(Entities.Vacation vacation, string stepTitle)
    {
        VacationHistory history = HistoryOfApprovingFactory.Create(vacation, GetTitle(), stepTitle);
        var result = await _repository.SaveAsync(history).ConfigureAwait(false);
        return result.IsSuccess ? new Result<bool>() : new Result<bool>().AddError(result.GetErrorsString());
    }
}
