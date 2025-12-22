namespace Vacation.Core.Domain.Entities;

/// <summary>
/// Represents a policy.
/// </summary>
public class Policy
{
    /// <summary>
    /// Gets or sets the policy ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the department ID.
    /// </summary>
    public int DepartmentId { get; set; }

    /// <summary>
    /// Gets or sets the policy code.
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// Gets or sets the sort order.
    /// </summary>
    public short Sort { get; set; }
}
