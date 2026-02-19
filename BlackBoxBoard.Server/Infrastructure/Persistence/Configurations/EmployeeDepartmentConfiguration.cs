using BlackBoxBoard.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlackBoxBoard.Server.Infrastructure.Persistence.Configurations;

public class EmployeeDepartmentConfiguration : IEntityTypeConfiguration<EmployeeDepartment>
{
    public void Configure(EntityTypeBuilder<EmployeeDepartment> builder)
    {
        builder.ToTable("EmployeeDepartments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.IsPrimary)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(x => x.FTE)
            .IsRequired()
            .HasPrecision(3, 2)
            .HasDefaultValue(1.0m);

        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        // Unique constraint to prevent duplicate assignments
        builder.HasIndex(x => new { x.EmployeeId, x.DepartmentId, x.StartDate })
            .IsUnique();

        // Relationships
        builder.HasOne(x => x.Employee)
            .WithMany(x => x.DepartmentAssignments)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Department)
            .WithMany(x => x.EmployeeAssignments)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Position)
            .WithMany(x => x.EmployeeDepartments)
            .HasForeignKey(x => x.PositionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
