using NetasBank.Context;
using NetasBank.Requests;

namespace NetasBank.Services;
public class BankService : IBankService
{
    private readonly NetasBankContext _context;
    public BankService(NetasBankContext context)
    {
        _context = context; 
    }

    public async Task<bool> Cancel(CancelTransactionRequestRecord request)
    {
        OperationContext context = new OperationContext(_context);
        return await context.Cancel(request.BankId, request);
    }

    public async Task<bool> Refund(RefundTransactionRequestRecord request)
    {
        OperationContext context = new OperationContext(_context);
        return await context.Refund(request.BankId, request);
    }

    public async Task<bool> Pay(CreateTransactionDetailsRequestRecord request)
    {
        OperationContext context = new OperationContext(_context);
        return await context.Pay(request.BankId, request);
    }
}
