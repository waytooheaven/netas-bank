using NetasBank.Models;
using System.Transactions;

namespace NetasBank.Responses;
public class ReportingResponse : ReportingBase
{
    public int BankId { get; set; }
    public int TotalAmount { get; set; }
    public int NetAmount { get; set; }
    public TransactionStatus TxStatus { get; set; }
    public string? OrderReference { get; set; }
    public DateTime TransactionDate { get; set; }
    public ICollection<ReportingTransactionDetail> TransactionDetails { get; set; } = new List<ReportingTransactionDetail>();
}
