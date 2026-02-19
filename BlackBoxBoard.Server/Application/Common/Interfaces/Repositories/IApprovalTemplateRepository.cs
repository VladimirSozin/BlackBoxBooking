using BlackBoxBoard.Server.Domain.References;

namespace BlackBoxBoard.Server.Application.Common.Interfaces.Repositories
{
    public interface IApprovalTemplateRepository
    {
        Task<ApprovalTemplate?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
