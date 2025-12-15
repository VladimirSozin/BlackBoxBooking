using Vacation.Core.Domain.Entities;

namespace Vacation.Core.Domain.Factories;

/// <summary>
/// Factory for creating history of approving requests.
/// </summary>
public static class HistoryOfApprovingFactory
{
    /// <summary>
    /// Creates a new instance of <see cref="HistoryOfApprovingRequest"/>.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="workflowTitle">The workflow title.</param>
    /// <param name="workflowStep">The workflow step.</param>
    /// <returns>The created history of approving request.</returns>
    public static HistoryOfApprovingRequest Create(Request request, string workflowTitle, string workflowStep)
    {
        ArgumentNullException.ThrowIfNull(request);

        return new HistoryOfApprovingRequest()
        {
            RequestId = request.Id,
            WorkFlowStepTitle = workflowStep,
            WorkFlowTitle = workflowTitle
        };
    }
}
