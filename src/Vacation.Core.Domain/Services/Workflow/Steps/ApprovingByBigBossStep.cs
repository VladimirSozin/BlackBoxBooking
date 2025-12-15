using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services.Workflow.Steps;

/// <summary>
/// Workflow step for approving by big boss.
/// </summary>
public class ApprovingByBigBossStep : IWorkflowStep
{
    /// <summary>
    /// Gets the title of the step.
    /// </summary>
    /// <returns>The title.</returns>
    public string GetTitle()
    {
        return "approving_by_big_boss";
    }

    /// <summary>
    /// Runs the step for the request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The result.</returns>
    public Result<bool> RunStep(Request request)
    {
        return new Result<bool>() { Data = true };
    }
}
