using BlackBoxBoard.Server.Modules.Shared.Application.Interfaces.Services;
using BlackBoxBoard.Server.Modules.Users.Domain.Interfaces;
using BlackBoxBoard.Server.Modules.Users.Infrastructure.Persistence.Repositories;
using BlackBoxBoard.Server.Modules.Users.Infrastructure.Services;
using BlackBoxBoard.Server.Modules.Users.Public;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BlackBoxBoard.Server.Modules.Users;

public static class ModuleRegistration
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(ModuleRegistration).Assembly));

        services.AddScoped<PasswordHasher>();
        services.AddScoped<JwtTokenGenerator>();

        return services;
    }
}