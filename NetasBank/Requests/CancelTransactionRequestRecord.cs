using NetasBank.Enums;

namespace NetasBank.Requests;
public sealed record CancelTransactionRequestRecord(Guid TransactionId, int Amount, BankEnum BankId);
