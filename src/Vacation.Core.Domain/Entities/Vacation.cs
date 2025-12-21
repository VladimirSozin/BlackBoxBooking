using Vacation.Core.Domain.ValueObjects;

namespace Vacation.Core.Domain.Entities;

/// <summary>
/// Represents a vacation request.
/// </summary>
public class Vacation
{
    /// <summary>
    /// Gets or sets the request ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the employee ID.
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// Gets or sets the department ID.
    /// </summary>
    public int DepartmentId { get; set; }

    /// <summary>
    /// Gets the status of the request.
    /// </summary>
    public readonly StatusOfRequest Status = StatusOfRequest.Draft;

    /// <summary>
    /// Gets or sets the type of request.
    /// </summary>
    public TypeOfRequest Type { get; set; }

    /// <summary>
    /// Gets or sets the start date.
    /// </summary>
    public DateTime DateStart { get; set; }

    /// <summary>
    /// Gets or sets the stop date.
    /// </summary>
    public DateTime DateStop { get; set; }

    /// <summary>
    /// Gets or sets the comment.
    /// </summary>
    public string? Comment { get; set; }
}
