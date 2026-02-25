using Microsoft.Extensions.DependencyInjection;
using BlackBoxBoard.Server.Modules.Shared.Application.Interfaces.Services;
using BlackBoxBoard.Server.Modules.Shared.Infrastructure.Services;

namespace BlackBoxBoard.Server.Modules.Shared;

public static class ModuleRegistration
{
    public static IServiceCollection AddSharedModule(this IServiceCollection services)
    {
        services.AddScoped<IDateTimeService, DateTimeService>();
        return services;
    }
}