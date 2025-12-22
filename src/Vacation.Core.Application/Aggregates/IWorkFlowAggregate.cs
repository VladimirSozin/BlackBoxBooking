using System.Threading.Tasks;
using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Helpers;

namespace Vacation.Core.Application.Aggregates;

public interface IWorkFlowAggregate
{
    Task<Result<bool>> RunNextAsync(Domain.Entities.Vacation vacation);
}