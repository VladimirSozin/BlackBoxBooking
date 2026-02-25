using BlackBoxBoard.Server.Modules.Employees;  
using BlackBoxBoard.Server.Modules.LeaveManagement;
using BlackBoxBoard.Server.Modules.ApprovalWorkflow;
using BlackBoxBoard.Server.Modules.References;
using BlackBoxBoard.Server.Modules.Users;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlackBoxBoard.Server.Modules.Employees.ModuleRegistration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlackBoxBoard.Server.Modules.LeaveManagement.ModuleRegistration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlackBoxBoard.Server.Modules.ApprovalWorkflow.ModuleRegistration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlackBoxBoard.Server.Modules.References.ModuleRegistration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlackBoxBoard.Server.Modules.Users.ModuleRegistration).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}