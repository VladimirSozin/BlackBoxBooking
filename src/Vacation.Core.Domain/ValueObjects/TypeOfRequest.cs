namespace Vacation.Core.Domain.ValueObjects;

/// <summary>
/// Represents the type of request.
/// </summary>
public enum TypeOfRequest
{
    /// <summary>
    /// Pregnancy request.
    /// </summary>
    Pregnancy,

    /// <summary>
    /// Paid vacation request.
    /// </summary>
    Paid,

    /// <summary>
    /// Unpaid vacation request.
    /// </summary>
    Unpaid
}
