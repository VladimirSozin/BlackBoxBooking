using BlackBoxBoard.Server.Domain.Entities;

namespace BlackBoxBoard.Server.Application.Common.Interfaces.Repositories
{
    public interface IRequestRepository
    {
        Task<Request?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Request>> GetByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken = default);
        void Add(Request request);
        void Update(Request request);
        void Delete(Request request);
    }
}
