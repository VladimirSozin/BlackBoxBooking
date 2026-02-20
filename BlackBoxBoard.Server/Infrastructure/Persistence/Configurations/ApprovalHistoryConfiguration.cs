using BlackBoxBoard.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlackBoxBoard.Server.Infrastructure.Persistence.Configurations;

public class ApprovalHistoryConfiguration : IEntityTypeConfiguration<ApprovalHistory>
{
    public void Configure(EntityTypeBuilder<ApprovalHistory> builder)
    {
        builder.ToTable("ApprovalHistories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StageNumber)
            .IsRequired();

        builder.Property(x => x.DecisionDate)
            .IsRequired();

        builder.Property(x => x.Comment)
            .HasMaxLength(500);

        // Relationships
        builder.HasOne(x => x.Request)
            .WithMany(x => x.ApprovalHistory)
            .HasForeignKey(x => x.RequestId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Approver)
            .WithMany(x => x.Approvals)
            .HasForeignKey(x => x.ApproverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Decision)
            .WithMany()
            .HasForeignKey(x => x.DecisionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
