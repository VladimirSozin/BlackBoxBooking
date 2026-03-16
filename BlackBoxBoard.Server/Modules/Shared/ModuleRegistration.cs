using BlackBoxBoard.Server.Modules.Shared.Application.Interfaces.Services;
using BlackBoxBoard.Server.Modules.Shared.Domain.Abstractions;
using BlackBoxBoard.Server.Modules.Shared.Infrastructure.Persistence;
using BlackBoxBoard.Server.Modules.Shared.Infrastructure.Services;

namespace BlackBoxBoard.Server.Modules.Shared;

public static class ModuleRegistration
{
    public static IServiceCollection AddSharedModule(this IServiceCollection services)
    {
        services.AddScoped<IDateTimeService, DateTimeService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}