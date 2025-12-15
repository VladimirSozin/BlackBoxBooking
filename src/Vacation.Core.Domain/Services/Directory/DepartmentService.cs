using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Domain.Services.Directory;

/// <summary>
/// Service for managing departments.
/// </summary>
public class DepartmentService : IDepartmentService
{
    private readonly IRepository<Department> _departmentRepository;

    DepartmentService(IRepository<Department> departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    /// <summary>
    /// Gets the workflow title asynchronously.
    /// </summary>
    /// <param name="departmentId">The department ID.</param>
    /// <returns>The result with the workflow title.</returns>
    public async Task<Result<string>> GetWorkflowTitleAsync(int departmentId)
    {
        Result<IReadOnlyList<Department>> departmentResult =
            await _departmentRepository.GetAsync(c => c.Id == departmentId).ConfigureAwait(false);
        if (!departmentResult.IsSuccess)
        {
            return new Result<string>().AddError(departmentResult.GetErrorsString());
        }

        string workFlowApprovingTitle = (departmentResult.Data != null)
            ? departmentResult.Data[0].WorkFlowApprovingTitle
            : String.Empty;
        if (string.IsNullOrEmpty(workFlowApprovingTitle))
        {
            return new Result<string>().AddError("WorkFlow approving title is empty");
        }

        return new Result<string> { Data = workFlowApprovingTitle };
    }
}