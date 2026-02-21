using BlackBoxBoard.Server.Domain.Entities;
using BlackBoxBoard.Server.Domain.References;
using Microsoft.EntityFrameworkCore;

namespace BlackBoxBoard.Server.Infrastructure.Persistence;

public static class DatabaseConfiguration
{
    public static void ConfigureModel(ModelBuilder modelBuilder)
    {
        ConfigureDecimalPrecision(modelBuilder);
        ConfigureCompositeIndexes(modelBuilder);
        ConfigureForeignKeyIndexes(modelBuilder);
        ConfigureStringLengths(modelBuilder);
        ConfigureDefaultValues(modelBuilder);
        ConfigureDeleteBehavior(modelBuilder);
        ConfigureNullableUniqueIndexes(modelBuilder);
    }

    #region Decimal Precision

    private static void ConfigureDecimalPrecision(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LeaveBalance>(entity =>
        {
            entity.Property(e => e.Entitled).HasPrecision(5, 1);
            entity.Property(e => e.Used).HasPrecision(5, 1);
            entity.Property(e => e.Planned).HasPrecision(5, 1);
        });

        modelBuilder.Entity<BalanceTransaction>(entity =>
        {
            entity.Property(e => e.Amount).HasPrecision(5, 1);
        });

        modelBuilder.Entity<EmployeeDepartment>(entity =>
        {
            entity.Property(e => e.FTE).HasPrecision(3, 2);
        });

        modelBuilder.Entity<Leave>(entity =>
        {
            entity.Property(e => e.DurationDays).HasPrecision(5, 1);
        });

        modelBuilder.Entity<LeaveType>(entity =>
        {
            entity.Property(e => e.AccrualRate).HasPrecision(5, 2);
        });
    }

    #endregion

    #region Composite Indexes

    private static void ConfigureCompositeIndexes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeDepartment>(entity =>
        {
            entity.HasIndex(e => new { e.EmployeeId, e.DepartmentId, e.StartDate })
                .IsUnique()
                .HasDatabaseName("IX_EmployeeDepartment_Employee_Department_StartDate");
        });

        modelBuilder.Entity<LeaveBalance>(entity =>
        {
            entity.HasIndex(e => new { e.EmployeeId, e.LeaveTypeId, e.Year })
                .IsUnique()
                .HasDatabaseName("IX_LeaveBalance_Employee_LeaveType_Year");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasIndex(e => new { e.EmployeeId, e.CreatedAt })
                .HasDatabaseName("IX_Request_EmployeeId_CreatedAt");
        });
    }

    #endregion

    #region Foreign Key Indexes

    private static void ConfigureForeignKeyIndexes(ModelBuilder modelBuilder)
    {
        // Leave indexes
        modelBuilder.Entity<Leave>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId).HasDatabaseName("IX_Leave_EmployeeId");
            entity.HasIndex(e => e.LeaveTypeId).HasDatabaseName("IX_Leave_LeaveTypeId");
            entity.HasIndex(e => e.StatusId).HasDatabaseName("IX_Leave_StatusId");
            entity.HasIndex(e => e.RequestId).HasDatabaseName("IX_Leave_RequestId");
        });

        // BalanceTransaction indexes
        modelBuilder.Entity<BalanceTransaction>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId).HasDatabaseName("IX_BalanceTransaction_EmployeeId");
            entity.HasIndex(e => e.LeaveTypeId).HasDatabaseName("IX_BalanceTransaction_LeaveTypeId");
            entity.HasIndex(e => e.TransactionTypeId).HasDatabaseName("IX_BalanceTransaction_TransactionTypeId");
            entity.HasIndex(e => e.LeaveId).HasDatabaseName("IX_BalanceTransaction_LeaveId");
            entity.HasIndex(e => e.RequestId).HasDatabaseName("IX_BalanceTransaction_RequestId");
        });

        // ApprovalHistory indexes
        modelBuilder.Entity<ApprovalHistory>(entity =>
        {
            entity.HasIndex(e => e.RequestId).HasDatabaseName("IX_ApprovalHistory_RequestId");
            entity.HasIndex(e => e.ApproverId).HasDatabaseName("IX_ApprovalHistory_ApproverId");
            entity.HasIndex(e => e.DecisionId).HasDatabaseName("IX_ApprovalHistory_DecisionId");
        });

        // Request indexes
        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasIndex(e => e.OperationTypeId).HasDatabaseName("IX_Request_OperationTypeId");
            entity.HasIndex(e => e.StatusId).HasDatabaseName("IX_Request_StatusId");
            entity.HasIndex(e => e.DepartmentId).HasDatabaseName("IX_Request_DepartmentId");
            entity.HasIndex(e => e.ApprovalTemplateId).HasDatabaseName("IX_Request_ApprovalTemplateId");
        });

        // EmployeeDepartment indexes
        modelBuilder.Entity<EmployeeDepartment>(entity =>
        {
            entity.HasIndex(e => e.DepartmentId).HasDatabaseName("IX_EmployeeDepartment_DepartmentId");
            entity.HasIndex(e => e.PositionId).HasDatabaseName("IX_EmployeeDepartment_PositionId");
        });

        // ApprovalStage indexes
        modelBuilder.Entity<ApprovalStage>(entity =>
        {
            entity.HasIndex(e => e.TemplateId).HasDatabaseName("IX_ApprovalStage_TemplateId");
            entity.HasIndex(e => e.RoleId).HasDatabaseName("IX_ApprovalStage_RoleId");
            entity.HasIndex(e => e.DepartmentId).HasDatabaseName("IX_ApprovalStage_DepartmentId");
            entity.HasIndex(e => e.PositionId).HasDatabaseName("IX_ApprovalStage_PositionId");
        });
    }

    #endregion

    #region String Lengths

    private static void ConfigureStringLengths(ModelBuilder modelBuilder)
    {
        // Users
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        // Employees
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.EmployeeNumber).IsRequired().HasMaxLength(50);
        });

        // Departments
        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        });

        // Positions
        modelBuilder.Entity<Position>(entity =>
        {
            entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        // Roles
        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        // LeaveType
        modelBuilder.Entity<LeaveType>(entity =>
        {
            entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        });

        // LeaveStatus
        modelBuilder.Entity<LeaveStatus>(entity =>
        {
            entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        });

        // RequestStatus
        modelBuilder.Entity<RequestStatus>(entity =>
        {
            entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        });

        // OperationType
        modelBuilder.Entity<OperationType>(entity =>
        {
            entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        });

        // DecisionType
        modelBuilder.Entity<DecisionType>(entity =>
        {
            entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        });

        // TransactionType
        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Sign).IsRequired().HasMaxLength(1);
        });

        // ApprovalTemplate
        modelBuilder.Entity<ApprovalTemplate>(entity =>
        {
            entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        // Requests
        modelBuilder.Entity<Request>(entity =>
        {
            entity.Property(e => e.RequestNumber).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Comment).HasMaxLength(1000);
        });

        // Leaves
        modelBuilder.Entity<Leave>(entity =>
        {
            entity.Property(e => e.Comment).HasMaxLength(500);
        });

        // ApprovalHistory
        modelBuilder.Entity<ApprovalHistory>(entity =>
        {
            entity.Property(e => e.Comment).HasMaxLength(500);
        });

        // BalanceTransaction
        modelBuilder.Entity<BalanceTransaction>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        // ApprovalStage
        modelBuilder.Entity<ApprovalStage>(entity =>
        {
            entity.Property(e => e.StageName).HasMaxLength(200);
        });
    }

    #endregion

    #region Default Values

    private static void ConfigureDefaultValues(ModelBuilder modelBuilder)
    {
        // LeaveBalance defaults
        modelBuilder.Entity<LeaveBalance>(entity =>
        {
            entity.Property(e => e.Entitled).HasDefaultValue(0);
            entity.Property(e => e.Used).HasDefaultValue(0);
            entity.Property(e => e.Planned).HasDefaultValue(0);
        });

        // EmployeeDepartment defaults
        modelBuilder.Entity<EmployeeDepartment>(entity =>
        {
            entity.Property(e => e.IsPrimary).HasDefaultValue(false);
            entity.Property(e => e.FTE).HasDefaultValue(1.0m);
        });

        // ApprovalStage defaults
        modelBuilder.Entity<ApprovalStage>(entity =>
        {
            entity.Property(e => e.IsRequired).HasDefaultValue(true);
        });

        // LeaveType defaults
        modelBuilder.Entity<LeaveType>(entity =>
        {
            entity.Property(e => e.MinDays).HasDefaultValue(1);
            entity.Property(e => e.MaxDays).HasDefaultValue(28);
        });

        // SortOrder defaults for reference entities
        modelBuilder.Entity<Role>(entity => entity.Property(e => e.SortOrder).HasDefaultValue(0));
        modelBuilder.Entity<LeaveType>(entity => entity.Property(e => e.SortOrder).HasDefaultValue(0));
        modelBuilder.Entity<LeaveStatus>(entity => entity.Property(e => e.SortOrder).HasDefaultValue(0));
        modelBuilder.Entity<RequestStatus>(entity => entity.Property(e => e.SortOrder).HasDefaultValue(0));
        modelBuilder.Entity<OperationType>(entity => entity.Property(e => e.SortOrder).HasDefaultValue(0));
        modelBuilder.Entity<DecisionType>(entity => entity.Property(e => e.SortOrder).HasDefaultValue(0));
        modelBuilder.Entity<TransactionType>(entity => entity.Property(e => e.SortOrder).HasDefaultValue(0));
        modelBuilder.Entity<ApprovalTemplate>(entity => entity.Property(e => e.SortOrder).HasDefaultValue(0));
    }

    #endregion

    #region Delete Behavior

    private static void ConfigureDeleteBehavior(ModelBuilder modelBuilder)
    {
        // Все внешние ключи - Restrict (защита от случайного удаления)
        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }

        // Исключение: каскадное удаление этапов при удалении шаблона
        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys())
            .Where(fk =>
                fk.PrincipalEntityType.ClrType == typeof(ApprovalTemplate) &&
                fk.Properties.Any(p => p.Name == "TemplateId")))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Cascade;
        }
    }

    #endregion

    #region Nullable Unique Indexes

    private static void ConfigureNullableUniqueIndexes(ModelBuilder modelBuilder)
    {
        // User.EmployeeId может быть null, поэтому добавляем фильтр для PostgreSQL
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId)
                .IsUnique()
                .HasDatabaseName("IX_User_EmployeeId");
            // Для PostgreSQL фильтр будет добавлен в миграции вручную или через провайдер-специфичный код
        });
    }

    #endregion
}