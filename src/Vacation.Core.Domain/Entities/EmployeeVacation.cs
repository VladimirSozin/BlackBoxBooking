namespace Vacation.Core.Domain.Entities;

/// <summary>
/// Represents the history of employee vacations.
/// </summary>
public class EmployeeVacation
{
    /// <summary>
    /// Gets or sets the employee ID.
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// Gets or sets the start date of vacation.
    /// </summary>
    public DateTime DateStartOfVacation { get; set; }
}
