using Vacation.Core.Domain.Services.Workflow.Steps;

namespace Vacation.Core.Domain.Factories;

/// <summary>
/// Factory for creating workflow steps.
/// </summary>
public static class WorkflowStepFactory
{
    /// <summary>
    /// Creates a workflow step based on the title.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <returns>The workflow step.</returns>
    public static IWorkflowStep Create(string title)
    {
        switch (title)
        {
            case "sending_email_to_boss":
                return new SendingEmailToBossStep();
            case "approving_big_boss":
                return new ApprovingByBossStep();
            case "approving_by_big_boss":
                return new ApprovingByBigBossStep();
            default:
                throw new ArgumentOutOfRangeException(nameof(title), title, null);
        }
    }
}
