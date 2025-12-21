using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Services;
using Vacation.Core.Domain.Services.Workflow;

namespace Vacation.Core.Application.Factories;

public class WorkflowFactory
{
    private readonly IRepository<VacationHistory> _repository;
    public WorkflowFactory(IRepository<VacationHistory> repository)
    {
        _repository = repository;
    }
    public IWorkflowService CreateWokflow(string title)
    {
        switch (title)
        {
            case "main":
                return new MainWorkflowService(_repository);
            default:
                throw new ArgumentException(title);
        }
    }
}