using BlackBoxBoard.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlackBoxBoard.Server.Infrastructure.Persistence.Configurations;

public class BalanceTransactionConfiguration : IEntityTypeConfiguration<BalanceTransaction>
{
    public void Configure(EntityTypeBuilder<BalanceTransaction> builder)
    {
        builder.ToTable("BalanceTransactions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.TransactionDate)
            .IsRequired();

        builder.Property(x => x.Amount)
            .IsRequired()
            .HasPrecision(5, 1);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        // Relationships
        builder.HasOne(x => x.Employee)
            .WithMany(x => x.BalanceTransactions)  
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.LeaveType)
            .WithMany()
            .HasForeignKey(x => x.LeaveTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TransactionType)
            .WithMany()
            .HasForeignKey(x => x.TransactionTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Leave)
            .WithMany()  
            .HasForeignKey(x => x.LeaveId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}