using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlackBoxBoard.Server.Infrastructure.Persistence.Configurations;

public class ApprovalStageConfiguration : IEntityTypeConfiguration<ApprovalStage>
{
    public void Configure(EntityTypeBuilder<ApprovalStage> builder)
    {
        builder.ToTable("ApprovalStages");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StageNumber)
            .IsRequired();

        builder.Property(x => x.StageName)
            .HasMaxLength(200);

        builder.Property(x => x.TimeoutHours);

        builder.Property(x => x.IsRequired)
            .IsRequired()
            .HasDefaultValue(true);

        // Relationships
        builder.HasOne(x => x.Template)
            .WithMany(x => x.Stages)
            .HasForeignKey(x => x.TemplateId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Role)
            .WithMany(x => x.ApprovalStages)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Department)
            .WithMany(x => x.ApprovalStages)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Position)
            .WithMany(x => x.ApprovalStages)
            .HasForeignKey(x => x.PositionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
