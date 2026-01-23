namespace Vacation.Core.Domain.Entities;

/// <summary>
/// Represents an employee.
/// </summary>
public class Employee
{
    /// <summary>
    /// Gets or sets the employee ID.
    /// </summary>
    public int Id  { get; set; }
    
    public string Username  { get; set; }
    
    public string Password  { get; set; }

    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    public required string LastName  { get; set; }

    /// <summary>
    /// Gets or sets the date of birth.
    /// </summary>
    public DateTime DateBirthday  { get; set; }

    /// <summary>
    /// Gets or sets the remaining days of vacation.
    /// </summary>
    public int RemainedDaysOfVacation  { get; set; }
}
