namespace Vacation.Core.Domain.Entities;

/// <summary>
/// Represents a department.
/// </summary>
public class Department
{
    /// <summary>
    /// Gets or sets the department ID.
    /// </summary>
    public int Id  { get; set; }

    /// <summary>
    /// Gets or sets the department title.
    /// </summary>
    public required string Title  { get; set; }

    /// <summary>
    /// Gets or sets the parent department ID.
    /// </summary>
    public int ParentId  { get; set; }

    /// <summary>
    /// Gets or sets the workflow approving title.
    /// </summary>
    public required string WorkFlowApprovingTitle { get; set; }
}
