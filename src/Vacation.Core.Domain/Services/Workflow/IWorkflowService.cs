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
    /// <param name="vacation">The request.</param>
    /// <returns>The result.</returns>
    Task<Result<bool>> RunAsync(Entities.Vacation vacation);

    /// <summary>
    /// Saves the step asynchronously.
    /// </summary>
    /// <param name="vacation">The request.</param>
    /// <param name="stepTitle">The step title.</param>
    /// <returns>The result.</returns>
    Task<Result<bool>> SaveStepAsync(Entities.Vacation vacation, string stepTitle);
}
