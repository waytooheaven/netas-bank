using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetasBank.Models;

namespace NetasBank.Configurations;

public class TransactionDetailsModelConfiguration : IEntityTypeConfiguration<TransactionDetailsModel>
{
    public void Configure(EntityTypeBuilder<TransactionDetailsModel> builder)
    {
        builder.ToTable("TransactionDetails");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Transaction).WithMany(x => x.TransactionDetails).HasForeignKey(x => x.TransactionId);
    }
}
