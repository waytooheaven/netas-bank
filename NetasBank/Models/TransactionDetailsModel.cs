using NetasBank.Enums;

namespace NetasBank.Models;
public sealed class TransactionDetailsModel : BaseModel
{
    public Guid TransactionId { get; set; }
    public TransactionType TxType { get; set; }
    public TransactionStatus TxStatus { get; set; }
    public int Amount { get; set; }
    public TransactionsModel? Transaction { get; set; }
}
