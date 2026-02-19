using BlackBoxBoard.Server.Domain.References;

namespace BlackBoxBoard.Server.Application.Common.Interfaces.Repositories
{
    public interface ILeaveTypeRepository
    {
        Task<LeaveType?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<LeaveType>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
