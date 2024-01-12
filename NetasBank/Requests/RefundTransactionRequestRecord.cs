using NetasBank.Enums;

namespace NetasBank.Requests;
public sealed record RefundTransactionRequestRecord(Guid TransactionId, int Amount, int BankId);
