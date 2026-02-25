using Microsoft.Extensions.DependencyInjection;
using BlackBoxBoard.Server.Modules.ApprovalWorkflow.Domain.Interfaces;
using BlackBoxBoard.Server.Modules.ApprovalWorkflow.Infrastructure.Persistence.Repositories;
using BlackBoxBoard.Server.Modules.ApprovalWorkflow.Public;
using BlackBoxBoard.Server.Modules.ApprovalWorkflow.Infrastructure.Services;

namespace BlackBoxBoard.Server.Modules.ApprovalWorkflow;

public static class ModuleRegistration
{
    public static IServiceCollection AddApprovalWorkflowModule(this IServiceCollection services)
    {
        services.AddScoped<IRequestRepository, RequestRepository>();
        services.AddScoped<IApprovalTemplateRepository, ApprovalTemplateRepository>();
        services.AddScoped<IApprovalHistoryRepository, ApprovalHistoryRepository>();

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(ModuleRegistration).Assembly));

        services.AddScoped<ApprovalRoutingService>();
        services.AddScoped<RequestNumberGenerator>();

        return services;
    }
}