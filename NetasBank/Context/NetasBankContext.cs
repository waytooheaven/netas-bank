using Microsoft.EntityFrameworkCore;
using NetasBank.Configurations;
using NetasBank.Models;

namespace NetasBank.Context;
public class NetasBankContext : DbContext
{
    public NetasBankContext(DbContextOptions<NetasBankContext> options)
    : base(options)
    { }
    protected NetasBankContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<TransactionDetailsModel> TransactionDetails { get; set; }
    public DbSet<TransactionsModel> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TransactionDetailsModelConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionModelConfiguration());
    }
}
