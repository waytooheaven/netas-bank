using NetasBank.Enums;

namespace NetasBank.Models;
public sealed class TransactionsModel : BaseModel
{
    public BankEnum BankId { get; set; }
    public int TotalAmount { get; set; }
    public int NetAmount { get; set; }
    public TransactionStatus TxStatus { get; set; }
    public string? OrderReference { get; set; }
    public DateTime TransactionDate { get; set; }
    public ICollection<TransactionDetailsModel> TransactionDetails { get; set; } = new List<TransactionDetailsModel>();
}
