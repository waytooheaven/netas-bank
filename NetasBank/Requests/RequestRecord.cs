using NetasBank.Enums;

namespace NetasBank.Requests;
public record RequestRecord
{
    public Guid TransactionId { get; set; }
    public int Amount { get; set; }
    public BankEnum BankId { get; set; }
}
