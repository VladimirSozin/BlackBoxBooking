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

        builder.HasIndex(r => r.RequestNumber)
            .IsUnique()
            .HasDatabaseName("IX_Request_RequestNumber");

        builder.HasIndex(r => r.EmployeeId)
            .HasDatabaseName("IX_Request_EmployeeId");

        builder.HasIndex(r => r.StatusId)
            .HasDatabaseName("IX_Request_StatusId");

        builder.HasIndex(r => new { r.EmployeeId, r.CreatedAt })
            .HasDatabaseName("IX_Request_EmployeeId_CreatedAt");

        builder.HasOne(r => r.OperationType)
            .WithMany() // НЕТ коллекции в OperationType!
            .HasForeignKey(r => r.OperationTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Status)
            .WithMany() 
            .HasForeignKey(r => r.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Employee)
            .WithMany(e => e.Requests) 
            .HasForeignKey(r => r.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Department)
            .WithMany() 
            .HasForeignKey(r => r.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.ApprovalTemplate)
            .WithMany() 
            .HasForeignKey(r => r.ApprovalTemplateId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
