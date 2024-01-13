using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetasBank.Models;

namespace NetasBank.Configurations;

public class TransactionModelConfiguration : IEntityTypeConfiguration<TransactionsModel>
{
    public void Configure(EntityTypeBuilder<TransactionsModel> builder)
    {
        builder.ToTable("Transactions");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.TransactionDetails).WithOne(x => x.Transaction).HasForeignKey(x => x.TransactionId);
    }
}
