using BlackBoxBoard.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlackBoxBoard.Server.Infrastructure.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.EmployeeNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.HireDate)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasIndex(e => e.EmployeeNumber)
            .IsUnique()
            .HasDatabaseName("IX_Employee_EmployeeNumber");

        builder.HasIndex(e => e.ManagerId)
            .HasDatabaseName("IX_Employee_ManagerId");

        builder.HasIndex(e => e.IsActive)
            .HasDatabaseName("IX_Employee_IsActive");

        builder.HasOne(x => x.Manager)
            .WithMany(x => x.Subordinates)
            .HasForeignKey(x => x.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
