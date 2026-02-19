using BlackBoxBoard.Server.Domain.Entities;
using BlackBoxBoard.Server.Domain.References;
using BlackBoxBoard.Server.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

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

        // Business entities
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
            base.OnModelCreating(modelBuilder);

            // Apply all configurations
            modelBuilder.ApplyConfiguration(new RequestStatusConfiguration());
            modelBuilder.ApplyConfiguration(new LeaveStatusConfiguration());
            modelBuilder.ApplyConfiguration(new OperationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new DecisionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ApprovalTemplateConfiguration());
            modelBuilder.ApplyConfiguration(new ApprovalStageConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeDepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new LeaveConfiguration());
            modelBuilder.ApplyConfiguration(new ApprovalHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new LeaveBalanceConfiguration());
            modelBuilder.ApplyConfiguration(new BalanceTransactionConfiguration());
        }
    }
}