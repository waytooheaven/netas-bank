namespace NetasBank.Requests;
public sealed record CancelTransactionRequestRecord(Guid TransactionId, int Amount, int BankId);
