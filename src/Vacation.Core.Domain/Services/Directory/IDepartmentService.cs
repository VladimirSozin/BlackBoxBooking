using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services.Directory;

/// <summary>
/// Service for managing departments.
/// </summary>
public interface IDepartmentService
{
    /// <summary>
    /// Gets the workflow title asynchronously.
    /// </summary>
    /// <param name="departmentId">The department ID.</param>
    /// <returns>The result with the workflow title.</returns>
    Task<Result<string>> GetWorkflowTitleAsync(int departmentId);
}
