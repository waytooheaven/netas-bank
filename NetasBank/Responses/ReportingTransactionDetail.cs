using NetasBank.Enums;

namespace NetasBank.Responses;
public class ReportingTransactionDetail : ReportingBase
{
    public Guid TransactionId { get; set; }
    public TransactionType TxType { get; set; }
    public TransactionStatus TxStatus { get; set; }
    public int Amount { get; set; }
}
