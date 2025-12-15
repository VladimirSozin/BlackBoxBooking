namespace Vacation.Core.Domain.ValueObjects;

/// <summary>
/// Represents the status of a request.
/// </summary>
public enum StatusOfRequest
{
    /// <summary>
    /// The request is in draft.
    /// </summary>
    Draft,

    /// <summary>
    /// The request is in progress.
    /// </summary>
    InProgress,

    /// <summary>
    /// The request is approved.
    /// </summary>
    Approved,

    /// <summary>
    /// The request is rejected.
    /// </summary>
    Rejected
}
