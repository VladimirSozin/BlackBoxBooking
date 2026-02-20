using BlackBoxBoard.Server.Domain.Entities;
using BlackBoxBoard.Server.Domain.References;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlackBoxBoard.Server.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<LeaveStatus> LeaveStatuses { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<DecisionType> DecisionTypes { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<ApprovalTemplate> ApprovalTemplates { get; set; }
        public DbSet<ApprovalStage> ApprovalStages { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<ApprovalHistory> ApprovalHistories { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set; }
        public DbSet<BalanceTransaction> BalanceTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}