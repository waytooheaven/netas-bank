using NetasBank.Requests;

namespace NetasBank.Banks;
public sealed class Garanti : BaseBank
{
    public override Task<bool> Cancel(CancelTransactionRequestRecord request)
    {
        throw new NotImplementedException();
    }

    public override Task<bool> Pay(CreateTransactionDetailsRequestRecord request)
    {
        throw new NotImplementedException();
    }

    public override Task<bool> Refund(RefundTransactionRequestRecord request)
    {
        throw new NotImplementedException();
    }
}
