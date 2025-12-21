namespace Vacation.Core.Domain.Entities;

/// <summary>
/// Represents the history of approving a request.
/// </summary>
public class VacationHistory
{
    /// <summary>
    /// Gets or sets the vacation ID.
    /// </summary>
    public int VacationId { get; set; }

    /// <summary>
    /// Gets or sets the workflow title.
    /// </summary>
    public required string WorkFlowTitle { get; set; }

    /// <summary>
    /// Gets or sets the workflow step title.
    /// </summary>
    public required string WorkFlowStepTitle { get; set; }
}
