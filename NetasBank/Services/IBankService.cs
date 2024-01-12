using NetasBank.Requests;

namespace NetasBank.Services;
public interface IBankService
{
    Task<bool> Pay(CreateTransactionDetailsRequestRecord request);
    Task<bool> Cancel(CancelTransactionRequestRecord request);
    Task<bool> Refund(RefundTransactionRequestRecord request);
}
