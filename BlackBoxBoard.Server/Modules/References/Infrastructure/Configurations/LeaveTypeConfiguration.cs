using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlackBoxBoard.Server.Modules.References.Domain.Entities;

namespace BlackBoxBoard.Server.Modules.References.Infrastructure.Persistence.Configurations;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.ToTable("LeaveTypes");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.MinDays)
            .HasDefaultValue(1);

        builder.Property(e => e.MaxDays)
            .HasDefaultValue(28);

        builder.Property(e => e.AccrualRate)
            .HasPrecision(5, 2);

        builder.Property(e => e.SortOrder)
            .HasDefaultValue(0);
    }
}