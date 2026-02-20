using BlackBoxBoard.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlackBoxBoard.Server.Infrastructure.Persistence.Configurations;

public class LeaveBalanceConfiguration : IEntityTypeConfiguration<LeaveBalance>
{
    public void Configure(EntityTypeBuilder<LeaveBalance> builder)
    {
        builder.ToTable("LeaveBalances");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Year)
            .IsRequired();

        builder.Property(x => x.Entitled)
            .IsRequired()
            .HasPrecision(5, 1)
            .HasDefaultValue(0);

        builder.Property(x => x.Used)
            .IsRequired()
            .HasPrecision(5, 1)
            .HasDefaultValue(0);

        builder.Property(x => x.Planned)
            .IsRequired()
            .HasPrecision(5, 1)
            .HasDefaultValue(0);

        builder.Property(x => x.CalculatedAt)
            .IsRequired();

        // Unique constraint for employee+type+year
        builder.HasIndex(x => new { x.EmployeeId, x.LeaveTypeId, x.Year })
            .IsUnique();

        // Relationships
        builder.HasOne(x => x.Employee)
            .WithMany(x => x.Balances)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.LeaveType)
            .WithMany()
            .HasForeignKey(x => x.LeaveTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
