using BlackBoxBoard.Server.Modules.Employees.Domain.Interfaces;
using BlackBoxBoard.Server.Modules.Employees.Infrastructure.Persistence.Repositories;
using BlackBoxBoard.Server.Modules.Employees.Infrastructure.Services;
using BlackBoxBoard.Server.Modules.Employees.Public;
using Microsoft.Extensions.DependencyInjection;

namespace BlackBoxBoard.Server.Modules.Employees;

public static class ModuleRegistration
{
    public static IServiceCollection AddEmployeesModule(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(ModuleRegistration).Assembly));

        services.AddScoped<EmployeeDomainService>();

        return services;
    }
}