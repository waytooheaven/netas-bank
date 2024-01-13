using Microsoft.AspNetCore.Mvc;
using NetasBank.Enums;

namespace NetasBank.Requests;

[Bind("TransactionId,Amount,BankId")]
public record RequestRecord
{
    public Guid TransactionId { get; set; }
    public int Amount { get; set; }
    public BankEnum BankId { get; set; }
}
