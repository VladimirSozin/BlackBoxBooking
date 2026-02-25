using Microsoft.Extensions.DependencyInjection;
using BlackBoxBoard.Server.Modules.References.Domain.Interfaces;
using BlackBoxBoard.Server.Modules.References.Infrastructure.Persistence.Repositories;
using BlackBoxBoard.Server.Modules.References.Public;

namespace BlackBoxBoard.Server.Modules.References;

public static class ModuleRegistration
{
    public static IServiceCollection AddReferencesModule(this IServiceCollection services)
    {
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<IOperationTypeRepository, OperationTypeRepository>();

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(ModuleRegistration).Assembly));

        return services;
    }
}