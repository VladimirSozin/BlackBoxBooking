using BlackBoxBoard.Server.Domain.Entities;

namespace BlackBoxBoard.Server.Application.Common.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        void Add(Employee employee);
        void Update(Employee employee);
    }
}
