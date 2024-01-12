namespace NetasBank.Requests;
public sealed record CreateTransactionDetailsRequestRecord(Guid TransactionId, int Amount, int BankId);
