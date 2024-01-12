using NetasBank.Requests;

namespace NetasBank.Banks;
public abstract class BaseBank
{
    public abstract Task<bool> Pay(CreateTransactionDetailsRequestRecord request);
    public abstract Task<bool> Cancel(CancelTransactionRequestRecord request);
    public abstract Task<bool> Refund(RefundTransactionRequestRecord request);
}
