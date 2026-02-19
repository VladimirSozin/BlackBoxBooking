using BlackBoxBoard.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlackBoxBoard.Server.Infrastructure.Persistence.Configurations;

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable("Requests");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.RequestNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Comment)
            .HasMaxLength(1000);

        builder.HasIndex(x => x.RequestNumber)
            .IsUnique();

        // Relationships
        builder.HasOne(x => x.OperationType)
            .WithMany(x => x.Requests)
            .HasForeignKey(x => x.OperationTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Status)
            .WithMany(x => x.Requests)
            .HasForeignKey(x => x.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Employee)
            .WithMany(x => x.Requests)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Department)
            .WithMany(x => x.Requests)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ApprovalTemplate)
            .WithMany(x => x.Requests)
            .HasForeignKey(x => x.ApprovalTemplateId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TargetLeave)
            .WithMany()
            .HasForeignKey(x => x.TargetLeaveId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
