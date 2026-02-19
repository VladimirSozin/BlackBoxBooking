using BlackBoxBoard.Server.Domain.References;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlackBoxBoard.Server.Infrastructure.Persistence.Configurations;

public class DecisionTypeConfiguration : IEntityTypeConfiguration<DecisionType>
{
    public void Configure(EntityTypeBuilder<DecisionType> builder)
    {
        builder.ToTable("DecisionTypes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.IsFinal)
            .IsRequired()
            .HasDefaultValue(false);

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
