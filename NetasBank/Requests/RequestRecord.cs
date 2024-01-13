using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetasBank.Enums;

namespace NetasBank.Requests;

[Bind("TransactionId,Amount,BankId")]
public record RequestRecord
{
    public Guid TransactionId { get; set; }
    public int Amount { get; set; }
    public BankEnum BankId { get; set; }
}
