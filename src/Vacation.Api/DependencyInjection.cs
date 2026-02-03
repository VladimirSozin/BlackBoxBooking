using Vacation.Core.Auth.Services;
using Vacation.Core.Domain.Entities;
using Vacation.Core.Domain.Services;
using Vacation.Infrastructure.Repositories;

namespace Vacation.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddScoped<IRepository<Employee>, DbRepository<Employee>>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRefreshTokenStore, InMemoryRefreshTokenStore>();
        return services;
    }
}