using BlackBoxBoard.Server.Modules.Shared.Application.Interfaces.Services;
using BlackBoxBoard.Server.Modules.Users.Domain.Interfaces;
using BlackBoxBoard.Server.Modules.Users.Infrastructure.Persistence.Repositories;
using BlackBoxBoard.Server.Modules.Users.Infrastructure.Services;
using AuthenticationService = BlackBoxBoard.Server.Modules.Users.Infrastructure.Services.AuthenticationService;
using IAuthenticationService = BlackBoxBoard.Server.Modules.Users.Public.IAuthenticationService;

namespace BlackBoxBoard.Server.Modules.Users;

public static class ModuleRegistration
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(ModuleRegistration).Assembly));

        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}