using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services.Workflow.Steps;

/// <summary>
/// Workflow step interface.
/// </summary>
public interface IWorkflowStep
{
    /// <summary>
    /// Gets the title of the workflow step.
    /// </summary>
    /// <returns>The title.</returns>
    string GetTitle();

    /// <summary>
    /// Runs the step for the request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The result of running the step.</returns>
    Result<bool> RunStep(Request request);
}
