using NetasBank.Requests;

namespace NetasBank.Services;
public class BankService : IBankService
{
    public BankService()
    {
    }

    public async Task<bool> Cancel(CancelTransactionRequestRecord request)
    {
        OperationContext context = new OperationContext();
        return await context.Cancel(request.BankId, request);
    }

    public async Task<bool> Refund(RefundTransactionRequestRecord request)
    {
        OperationContext context = new OperationContext();
        return await context.Refund(request.BankId, request);
    }

    public async Task<bool> Pay(CreateTransactionDetailsRequestRecord request)
    {
        OperationContext context = new OperationContext();
        return await context.Pay(request.BankId, request);
    }
}
