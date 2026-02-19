using BlackBoxBoard.Server.Domain.References;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlackBoxBoard.Server.Infrastructure.Persistence.Configurations;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.ToTable("LeaveTypes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.IsPaid)
            .IsRequired();

        builder.Property(x => x.AffectsBalance)
            .IsRequired();

        builder.Property(x => x.MinDays)
            .IsRequired()
            .HasDefaultValue(1);

        builder.Property(x => x.MaxDays)
            .IsRequired()
            .HasDefaultValue(28);

        builder.Property(x => x.AccrualRate)
            .HasPrecision(5, 2);

        builder.Property(x => x.SortOrder)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasIndex(x => x.Code)
            .IsUnique();
    }
}
