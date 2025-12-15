using System.Threading.Tasks;
using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services.Workflow;

/// <summary>
/// Workflow service interface.
/// </summary>
public interface IWorkflowService
{
    /// <summary>
    /// Gets the title.
    /// </summary>
    /// <returns>The title.</returns>
    string GetTitle();

    /// <summary>
    /// Runs the workflow asynchronously.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The result.</returns>
    Task<Result<bool>> RunAsync(Request request);

    /// <summary>
    /// Saves the step asynchronously.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="stepTitle">The step title.</param>
    /// <returns>The result.</returns>
    Task<Result<bool>> SaveStepAsync(Request request, string stepTitle);
}
