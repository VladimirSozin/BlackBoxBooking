namespace Vacation.Core.Domain.Entities;

/// <summary>
/// Represents a position.
/// </summary>
public class Position
{
    /// <summary>
    /// Gets or sets the position ID.
    /// </summary>
    public int Id  { get; set; }

    /// <summary>
    /// Gets or sets the position title.
    /// </summary>
    public required string Title  { get; set; }
}
