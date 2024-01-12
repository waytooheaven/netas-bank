using NetasBank.Enums;

namespace NetasBank.Requests;
public sealed record CreateTransactionDetailsRequestRecord(Guid TransactionId, int Amount, BankEnum BankId);
