namespace Vacation.Core.Domain.Entities;

/// <summary>
/// Represents the history of approving a request.
/// </summary>
public class HistoryOfApprovingRequest
{
    /// <summary>
    /// Gets or sets the request ID.
    /// </summary>
    public int RequestId { get; set; }

    /// <summary>
    /// Gets or sets the workflow title.
    /// </summary>
    public required string WorkFlowTitle { get; set; }

    /// <summary>
    /// Gets or sets the workflow step title.
    /// </summary>
    public required string WorkFlowStepTitle { get; set; }
}
